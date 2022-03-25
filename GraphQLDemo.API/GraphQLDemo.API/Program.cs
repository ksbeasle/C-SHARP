using GraphQLDemo.API.Mutations;
using GraphQLDemo.API.Queries;
using GraphQLDemo.API.Services;
using GraphQLDemo.API.Services.Courses;
using GraphQLDemo.API.Subscriptions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["ConnectionStrings:default"];
Console.WriteLine(connectionString);

// Graphql
builder.Services
    .AddPooledDbContextFactory<SchoolDbContext>(o => o.UseSqlite(connectionString))
    .AddScoped<CoursesRepository>()
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions()
    .AddType<ExampleQuery>();

var app = builder.Build();
using (IServiceScope scope = app.Services.CreateScope()) 
{
    IDbContextFactory<SchoolDbContext> contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<SchoolDbContext>>();

    using(SchoolDbContext context = contextFactory.CreateDbContext())
    {
        context.Database.Migrate();
    }
}

app.UseWebSockets(); // subscription
app.MapGraphQL();

app.Run();
