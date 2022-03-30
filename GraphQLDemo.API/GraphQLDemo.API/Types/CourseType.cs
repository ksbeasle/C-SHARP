using GraphQLDemo.API.DataLoaders;
using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.Models;
using GraphQLDemo.API.Services.Instructors;

namespace GraphQLDemo.API.Types
{
    public class CourseType
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Subject Sub { get; set; }
        //public InstructorType? Instructor { get; set; }
        public Guid InstructorId { get; set; }
        [GraphQLNonNullType]
        public async Task<InstructorType?> Instructor([Service] InstructorDataLoader dataLoader)
        {
            InstructorDTO instructorDto = await dataLoader.LoadAsync(InstructorId, CancellationToken.None);
            return new InstructorType()
            {
                Id = instructorDto.Id,
                Name = instructorDto.Name,
                salary = instructorDto.salary
            };

        }
        public IEnumerable<StudentType>? Students { get; set; }


        // Resolver on a query type
        public string Description()
        {
            return $"A Course. {Id}";
        }
    }
}
