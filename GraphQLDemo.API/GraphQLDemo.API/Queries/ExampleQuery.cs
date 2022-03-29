using GraphQLDemo.API.Services.Courses;
using GraphQLDemo.API.Types;

namespace GraphQLDemo.API.Queries
{
    public partial class ExampleQuery : Query
    {
        public ExampleQuery(CoursesRepository coursesRepository) : base(coursesRepository)
        {
        }

        public ExampleType GetExample() =>
         new ExampleType
            {
                name = "A Name"
            };
        public CourseType getMe() =>
            new CourseType { };
    }
}
