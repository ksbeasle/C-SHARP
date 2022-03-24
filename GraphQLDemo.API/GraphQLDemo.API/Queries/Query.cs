using Bogus;
using GraphQLDemo.API.Types;
using GraphQLDemo.API.Models;

namespace GraphQLDemo.API.Queries
{
    public partial class Query
    {
        // Since we technically have no datasource we are going to mock data with the "Bogus" package
        private readonly Faker<InstructorType> _instructorFaker;
        private readonly Faker<CourseType> _courseFaker;
        private readonly Faker<StudentType> _studentFaker;

        public Query()
        {
            _instructorFaker = new Faker<InstructorType>()
                .RuleFor(r => r.Id, f => Guid.NewGuid())
                .RuleFor(r => r.Name, f => f.Name.FirstName())
                .RuleFor(r => r.salary, f => f.Random.Double(0, 100000));

            _studentFaker = new Faker<StudentType>()
                .RuleFor(r => r.Id, f => Guid.NewGuid())
                .RuleFor(r => r.Name, f => f.Name.FirstName());

            _courseFaker = new Faker<CourseType>()
                .RuleFor(r => r.Id, f => Guid.NewGuid())
                .RuleFor(r => r.Name, f => f.Name.FirstName())
                .RuleFor(r => r.Sub, f => f.PickRandom<Subject>())
                .RuleFor(r => r.Instructor, f => _instructorFaker.Generate())
                .RuleFor(r => r.Students, f => _studentFaker.Generate(3));
        }
        public IEnumerable<CourseType> GetCourses()
        {   
            return _courseFaker.Generate(5);
        }

        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {
            await Task.Delay(5000);

            CourseType course = _courseFaker.Generate();
            course.Id = id;

            return course;
        }
    }
}
