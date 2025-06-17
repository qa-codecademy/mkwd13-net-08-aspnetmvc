using DemoApp.Database;
using DemoApp.Models.Domain;
using DemoApp.Models.ViewModels;

namespace DemoApp.Services
{
    public class CourseService
    {
        public List<CourseViewModel> GetCoursesWithMoreThanNineClasses()
        {
            var courses = StaticDb.Courses.Where(x => x.NumberOfClasses > 9).ToList(); //here we have a Lits<Course> - we are working with domain models

            //we need to return List<CourseViewModel> - we need to map the domain model to the view model
            List<CourseViewModel> result = new List<CourseViewModel>();

            if(courses!= null && courses.Count > 0) {
                foreach (Course course in courses) //we need to map a list of domain models to a list of view models, we need to iterate through the list
                {
                    result.Add(new CourseViewModel()
                    {
                        Name = course.Name,
                        NumberOfClasses = course.NumberOfClasses,
                    });
                }
            }

            return result;
        }
    }
}
