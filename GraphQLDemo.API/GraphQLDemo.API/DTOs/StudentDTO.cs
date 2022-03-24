namespace GraphQLDemo.API.DTOs
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<CourseDTO> Courses { get; set; }
    }
}
