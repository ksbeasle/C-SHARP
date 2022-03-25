

using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.Services.Courses;
using GraphQLDemo.API.Subscriptions;
using GraphQLDemo.API.Types;
using HotChocolate.Subscriptions;
using static GraphQLDemo.API.Types.CourseType;

namespace GraphQLDemo.API.Mutations
{
    public class Mutation
    {
        private readonly CoursesRepository _coursesRepository;
        public Mutation(CoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
            
        public async Task<CourseResult> createCourse(CourseInputType inputType, [Service] ITopicEventSender topicEventSender)
        {
            CourseDTO courseDTO = new CourseDTO()
            {
                Name = inputType.Name,
                Sub = inputType.sub,
                instructorId = inputType.instructorId
            };

            courseDTO = await _coursesRepository.Create(courseDTO);
            CourseResult course = new CourseResult()
            {
                Id =  courseDTO.Id,
                Name = courseDTO.Name,
                Sub = courseDTO.Sub,
                instructorId = courseDTO.instructorId
            };

            await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), course);
            return course;
        }

        public async Task<CourseResult> updateCourse(Guid id, CourseInputType inputType, [Service] ITopicEventSender topicEventSender)
        {
            CourseDTO courseDTO = new CourseDTO()
            {
                Id = id,
                Name = inputType.Name,
                Sub = inputType.sub,
                instructorId = inputType.instructorId
            };

            courseDTO = await _coursesRepository.Update(courseDTO);

            CourseResult course = new CourseResult()
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                Sub = courseDTO.Sub,
                instructorId = courseDTO.instructorId
            };

            // custom topic name
            string updateCourseTopic = $"{course.Id}_{nameof(Subscription.CourseUpdated)}";
            await topicEventSender.SendAsync(updateCourseTopic, course);
            return course;

        }

        public async Task<bool> removeCourse(Guid id)
        {
            return await _coursesRepository.Delete(id);
        }
    }
}
