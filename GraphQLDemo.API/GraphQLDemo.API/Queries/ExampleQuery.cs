using GraphQLDemo.API.Types;

namespace GraphQLDemo.API.Queries
{
    public partial class ExampleQuery : Query
    {
        public ExampleType GetExample() =>
         new ExampleType
            {
                name = "A Name"
            };
        public CourseType getMe() =>
            new CourseType { };
    }
}
