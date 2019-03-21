using System.Collections.Generic;

namespace Api.Models
{
    public class Subject: ModelBase
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public string IdTeacherTeachingPlan { get; set; }
        public User TeacherTeachingPlan { get; set; }

        public int TheoryWorkload { get; set; }
        public int PracticalWorkload { get; set; }

        // TODO: fazer n pra n
        public List<Course> Courses { get; set; }
    }
}