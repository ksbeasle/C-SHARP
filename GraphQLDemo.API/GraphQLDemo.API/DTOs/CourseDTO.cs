using GraphQLDemo.API.Models;

namespace GraphQLDemo.API.DTOs
{
    public class CourseDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Subject Sub { get; set; }
        public Guid instructorId { get; set; }
        public InstructorDTO? Instructor { get; set; }
        public IEnumerable<StudentDTO>? Students { get; set; }
    }
}
