
using System.Collections.Generic;

namespace Api.Models
{
    public class User: ModelBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AcademicTitle { get; set; }

        public bool Administrator { get; set; }
        public bool Coordinator { get; set; }
        public bool Professor { get; set; }

        public List<CourseUser> Courses { get; set; }
        public List<Subject> TeachingPlanResponsibleSubjects { get; set; }
        public List<Class> ProfessorClasses { get; set; }
    }
}