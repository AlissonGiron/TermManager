using System.Collections.Generic;

namespace Api.Models
{
    public class Subject: ModelBase
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public int IdTeacherTeachingPlan { get; set; }
        public User ProfessorTeachingPlan { get; set; }

        public int TheoryWorkload { get; set; }
        public int PracticalWorkload { get; set; }

        public List<CourseSubject> Courses { get; set; }
        public List<Class> Classes { get; set; }
    }
}