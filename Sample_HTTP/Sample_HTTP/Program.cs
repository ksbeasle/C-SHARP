using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sample_Http
{
    public class sampleHttp
    {

        private static readonly HttpClient client = new HttpClient();
        /* public static async void Main(string[] args)
         {
             await ProcessRepositories();
         }*/

        static async Task Main(string[] args)
        {
            var r = await ProcessRepositories();
            foreach(var repos in r)
            {
                Console.WriteLine(repos.Name);
                Console.WriteLine(repos.Description);
                Console.WriteLine(repos.GitHubHomeUrl);
                Console.WriteLine(repos.Homepage);
                Console.WriteLine(repos.Watchers);
                Console.WriteLine(repos.LastPush);
            }
        }


        private static async Task<List<Repository>> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var task = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await task);

            return repositories;
        }
#region Model/DTO whatever
        public class Repository
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }
            [JsonPropertyName("description")]
            public string Description { get; set; }
            [JsonPropertyName("html_url")]
            public Uri GitHubHomeUrl { get; set; }
            [JsonPropertyName("homepage")]
            public Uri Homepage { get; set; }
            [JsonPropertyName("watchers")]
            public int Watchers { get; set; }
            [JsonPropertyName("pushed_at")]
            public DateTime LastPushUtc { get; set; }
            public DateTime LastPush => LastPushUtc.ToLocalTime();
        }
        #endregion
    }
}