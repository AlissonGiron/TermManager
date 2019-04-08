using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Api.Models
{
    public class User: IdentityUser<int>, IModel
    {
        public string AcademicTitle { get; set; }

        public bool Administrator { get; set; }
        public bool Coordinator { get; set; }
        public bool Professor { get; set; }

        public string Password { get; set; }

        public List<CourseUser> Courses { get; set; }
        public List<Subject> TeachingPlanResponsibleSubjects { get; set; }
        public List<Class> ProfessorClasses { get; set; }
    }
}