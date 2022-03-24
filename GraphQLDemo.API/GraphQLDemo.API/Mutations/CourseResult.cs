using GraphQLDemo.API.Models;
using static GraphQLDemo.API.Types.CourseType;

namespace GraphQLDemo.API.Mutations
{
    public class CourseResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Sub { get; set; }
        public Guid instructorId { get; set; }
    }
}
