using System.Collections.Generic;

namespace Api.Models
{
    public class Goal: ModelBase
    {
        public int IdCourse { get; set; }
        public Course Course { get; set; }

        public string Description { get; set; }

        public List<SubjectCurriculumGoal> SubjectCurriculums { get; set; }

        public Goal()
        {
            SubjectCurriculums = new List<SubjectCurriculumGoal>();
        }
    }
}