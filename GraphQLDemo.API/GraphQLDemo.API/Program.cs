using GraphQLDemo.API.Mutations;
using GraphQLDemo.API.Queries;
using GraphQLDemo.API.Services;
using GraphQLDemo.API.Subscriptions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["ConnectionStrings:default"];

// Graphql
builder.Services
    .AddPooledDbContextFactory<SchoolDbContext>(o => o.UseSqlite(connectionString))
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
