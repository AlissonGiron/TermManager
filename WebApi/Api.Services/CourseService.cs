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

        public bool SaveCoordinators(int id, int[] coordinators)
        {
            try
            {
                Course course = FirstOrDefault(new Query<Course>().Filter(t => t.Id == id).Include(s => s.Users));
                List<User> selectedUsers = Read<User>(t => coordinators.Contains(t.Id)).ToList();

                foreach (CourseUser toDelete in course.Users.Where(s => s.Type == Enums.CourseUserType.Coordinator && !coordinators.Contains(s.IdCourse)))
                {
                    Delete(toDelete);
                }

                foreach (User user in selectedUsers)
                {
                    if (FirstOrDefault<CourseUser>(t => t.IdCourse == id && t.IdUser == user.Id) != null) continue;

                    Create(new CourseUser()
                    {
                        IdCourse = id,
                        IdUser = user.Id,
                        Type = Enums.CourseUserType.Coordinator
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

        public bool SaveNDE(int id, int[] NDE)
        {
            try
            {
                Course course = FirstOrDefault(new Query<Course>().Filter(t => t.Id == id).Include(s => s.Users));
                List<User> selectedUsers = Read<User>(t => NDE.Contains(t.Id)).ToList();

                foreach (CourseUser toDelete in course.Users.Where(s => s.Type == Enums.CourseUserType.NDE && !NDE.Contains(s.IdCourse)))
                {
                    Delete(toDelete);
                }

                foreach (User user in selectedUsers)
                {
                    if (FirstOrDefault<CourseUser>(t => t.IdCourse == id && t.IdUser == user.Id) != null) continue;

                    Create(new CourseUser()
                    {
                        IdCourse = id,
                        IdUser = user.Id,
                        Type = Enums.CourseUserType.NDE
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

                foreach (Subject subject in selectedSubjects)
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