using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Kafka.Public;
using Kafka.Public.Loggers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace officialKafka
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>

            Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, collection) =>
            {
                //ORDER MATTERS HERE -- CONSUMER FIRST
                collection.AddHostedService<KafkaConsumerHostedService>(); // CONSUMER SERVICE
                collection.AddHostedService<KafkaProducerHostedService>(); // PRODUCER SERVICE
            });

            
    }
    // --- CONSUMER ---
    public class KafkaConsumerHostedService : IHostedService
    {
        private readonly ILogger<KafkaConsumerHostedService> _logger;
        private ClusterClient _cluster; 
        public KafkaConsumerHostedService(ILogger<KafkaConsumerHostedService> logger)
        {
            _logger = logger;
            _cluster = new ClusterClient(new Configuration
            {
                Seeds = "localhost:9092"
            }, new ConsoleLogger());
        }
        // Consume actual messages here
        Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            _cluster.ConsumeFromLatest("demo");
            _cluster.MessageReceived += record =>
            {
                _logger.LogInformation($"Received: {Encoding.UTF8.GetString(record.Value as byte[])}");
            };

            return Task.CompletedTask;
        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            _cluster?.Dispose();
            return Task.CompletedTask;
        }
    }

    // --- PRODUCER --- 
    public class KafkaProducerHostedService : IHostedService
    {

        private readonly ILogger<KafkaProducerHostedService> _logger;
        private IProducer<Null, string> _producer;

        public KafkaProducerHostedService(ILogger<KafkaProducerHostedService> logger)
        {
            _logger = logger;
            var config = new ProducerConfig()
            {
                BootstrapServers = "localhost:9092"
            };

            _producer = new ProducerBuilder<Null, string>(config).Build();
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            for(var i = 0; i < 100; i++)
            {
                var value = $"HelloWorld {i}";
                _logger.LogInformation(value);
                await _producer.ProduceAsync("demo", new Message<Null, string>()
                {
                    Value = value
                }, cancellationToken);
            }
            // Sending one last message just to see it happen in real time -- 10 second wait and produce a new message
            System.Threading.Thread.Sleep(10000);
            await _producer.ProduceAsync("demo", new Message<Null, string>()
            {
                Value = "ONE LAST THING"
            }, cancellationToken);

            _producer.Flush(TimeSpan.FromSeconds(10));
           // throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _producer?.Dispose();
            return Task.CompletedTask;
           // throw new NotImplementedException();
        }
    }
}
