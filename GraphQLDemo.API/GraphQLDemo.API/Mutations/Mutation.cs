
using GraphQLDemo.API.Subscriptions;
using GraphQLDemo.API.Types;
using HotChocolate.Subscriptions;
using static GraphQLDemo.API.Types.CourseType;

namespace GraphQLDemo.API.Mutations
{
    public class Mutation
    {
        private readonly List<CourseResult> _courses;
        public Mutation()
        {
            _courses = new List<CourseResult>();
        }
            
        public async Task<CourseResult> createCourse(CourseInputType inputType, [Service] ITopicEventSender topicEventSender)
        {
            CourseResult course = new CourseResult()
            {
                Id =  Guid.NewGuid(),
                Name = inputType.Name,
                Sub = inputType.sub,
                instructorId = inputType.instructorId
            };
            _courses.Add(course);
            await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), course);
            return course;
        }

        public async Task<CourseResult> updateCourse(Guid id, CourseInputType inputType, [Service] ITopicEventSender topicEventSender)
        {
            CourseResult? course = _courses.FirstOrDefault(c => c.Id == id);

            if(course == null)
            {
                throw new GraphQLException(new Error("Course not found.", "COURSE_NOT_FOUND")); 
                //throw new Exception("Course not found.");
            }

            course.Name = inputType.Name;
            course.Sub = inputType.sub;
            course.instructorId = inputType.instructorId;
            // custom topic name
            string updateCourseTopic = $"{course.Id}_{nameof(Subscription.CourseUpdated)}";
            await topicEventSender.SendAsync(updateCourseTopic, course);
            return course;

        }

        public bool removeCourse(Guid id)
        {
            return _courses.RemoveAll(c => c.Id == id) >= 1;
        }
    }
}
