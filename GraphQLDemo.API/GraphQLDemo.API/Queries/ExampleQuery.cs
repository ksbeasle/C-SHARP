using GraphQLDemo.API.Types;

namespace GraphQLDemo.API.Queries
{
    public class ExampleQuery
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
