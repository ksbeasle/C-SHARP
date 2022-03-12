namespace GraphQLDemo.API.Types
{
    public class CourseType
    {
        public enum Subject
        {
            Math,
            Science,
            History
        }
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Subject subject { get; set; }
        public InstructorType? instructor { get; set; }
        public IEnumerable<StudentType>? Students { get; set; }


        // Resolver on a query type
        public string Description()
        {
            return $"A Course. {Id}";
        }
    }
}
