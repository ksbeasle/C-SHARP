using GraphQLDemo.API.Mutations;
using GraphQLDemo.API.Queries;

var builder = WebApplication.CreateBuilder(args);


// Graphql
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<ExampleQuery>();

var app = builder.Build();
app.MapGraphQL();

app.Run();
