using GraphQLDemo.API.Queries;

var builder = WebApplication.CreateBuilder(args);


// Graphql
builder.Services
    .AddGraphQLServer()
    //.AddQueryType<ExampleQuery>()
    .AddQueryType<Query>();

var app = builder.Build();
app.MapGraphQL();

app.Run();
