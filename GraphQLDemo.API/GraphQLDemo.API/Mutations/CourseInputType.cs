using GraphQLDemo.API.Models;
using static GraphQLDemo.API.Types.CourseType;

namespace GraphQLDemo.API.Mutations
{
    public class CourseInputType
    {
        public string Name { get; set; }
        public Subject sub { get; set; }
        public Guid instructorId { get; set; }
    }
}
