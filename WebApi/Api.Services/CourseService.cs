using Api.Infrastructure;
using Api.Infrastructure.Helpers;
using Api.Interfaces;
using Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Api.Services
{
    public class CourseService : ServiceBase, ICourseService
    {
        public CourseService(Context context) : base(context) {}

        public bool SaveSubjects(int id, int[] subjects)
        {
            try
            {
                Course course = FirstOrDefault(new Query<Course>().Filter(t => t.Id == id).Include(s => s.Subjects));
                List<Subject> selectedSubjects = Read<Subject>(t => subjects.Contains(t.Id)).ToList();

                foreach (CourseSubject toDelete in course.Subjects.Where(s => !subjects.Contains(s.IdSubject)))
                {
                    Delete(toDelete);
                }

                foreach (var subject in selectedSubjects)
                {
                    if (FirstOrDefault<CourseSubject>(t => t.IdCourse == id && t.IdSubject == subject.Id) != null) continue;

                    Create(new CourseSubject()
                    {
                        IdCourse = id,
                        IdSubject = subject.Id
                    });
                }

                Save();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}