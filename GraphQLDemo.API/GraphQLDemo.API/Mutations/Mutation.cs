
using GraphQLDemo.API.Types;
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
            
        public CourseResult createCourse(CourseInputType inputType)
        {
            CourseResult courseResult = new CourseResult()
            {
                Id =  Guid.NewGuid(),
                Name = inputType.Name,
                Sub = inputType.sub,
                instructorId = inputType.instructorId
            };
            _courses.Add(courseResult);
            return courseResult;
        }

        public CourseResult updateCourse(Guid id, CourseInputType inputType)
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
            return course;

        }

        public bool removeCourse(Guid id)
        {
            return _courses.RemoveAll(c => c.Id == id) >= 1;
        }
    }
}
