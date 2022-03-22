using GraphQLDemo.API.Models;

namespace GraphQLDemo.API.Types
{
    public class CourseType
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Subject Sub { get; set; }
        public InstructorType? Instructor { get; set; }
        public IEnumerable<StudentType>? Students { get; set; }


        // Resolver on a query type
        public string Description()
        {
            return $"A Course. {Id}";
        }
    }
}
