using GraphQLDemo.API.Mutations;
using GraphQLDemo.API.Queries;
using GraphQLDemo.API.Subscriptions;

var builder = WebApplication.CreateBuilder(args);


// Graphql
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions()
    .AddType<ExampleQuery>();

var app = builder.Build();
app.UseWebSockets(); // subscription
app.MapGraphQL();

app.Run();
