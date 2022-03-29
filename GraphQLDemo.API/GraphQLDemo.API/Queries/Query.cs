using Bogus;
using GraphQLDemo.API.Types;
using GraphQLDemo.API.Models;
using GraphQLDemo.API.Services.Courses;
using GraphQLDemo.API.DTOs;

namespace GraphQLDemo.API.Queries
{
    public partial class Query
    {
        private readonly CoursesRepository _coursesRepository;

        public Query(CoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        // Since we technically have no datasource we are going to mock data with the "Bogus" package
        /*
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
        }*/
        public async Task<IEnumerable<CourseType>> GetCourses()
        {
            IEnumerable<CourseDTO> courseDTOs =  await _coursesRepository.GetAll();
            return courseDTOs.Select(c => new CourseType()
            {
                Id = c.Id,
                Name = c.Name,
                Sub = c.Sub,
                Instructor = new InstructorType()
                {
                    Id = c.instructorId,
                    Name = c.Name,
                    salary = c.Instructor.salary
                }
            });
           // return _courseFaker.Generate(5);
        }

        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {
            CourseDTO courseDTO = await _coursesRepository.GetById(id);

            return new CourseType()
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                Sub = courseDTO.Sub,
                Instructor = new InstructorType()
                {
                    Id = courseDTO.instructorId,
                    Name = courseDTO.Name,
                    salary = courseDTO.Instructor.salary
                }
            };
            /*
            await Task.Delay(5000);

            CourseType course = _courseFaker.Generate();
            course.Id = id;

            return course;
            */
        }
    }
}
