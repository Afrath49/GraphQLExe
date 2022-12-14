


using GraphQLExcercise.API.Schema.Queries;

namespace GraphQLExcercise.API.Schema.Mutations
{
    public class Mutation
    {

        private readonly List<CourseResult> _courses;

        public Mutation()
        {
            _courses = new List<CourseResult>();
        }
        public CourseResult CreateCourse(CourseInput courseInput)
        {
            CourseResult courseType = new CourseResult()
            {
                Id = Guid.NewGuid(),
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                InstructorId = courseInput.InstructorId
            };
            _courses.Add(courseType);

            return courseType;

        }

        public CourseResult UpdatCourse(Guid id,CourseInput courseInput)
        {
            CourseResult course = _courses.FirstOrDefault(c => c.Id == id);
            if(course == null)
            {
                throw new GraphQLException(new Error("Course Not Found","COURSE NOT FOUND"));
            }

            course.Name = courseInput.Name;
            course.Subject = courseInput.Subject;
            course.InstructorId = courseInput.InstructorId;

            return course;
        }

        public bool DeleteCourse(Guid id)
        {
            return _courses.RemoveAll(c => c.Id == id) >= 1;
        }
    }
}
