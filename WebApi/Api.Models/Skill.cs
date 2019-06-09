using System.Collections.Generic;

namespace Api.Models
{
    public class Skill: ModelBase
    {
        public int IdCourse { get; set; }
        public Course Course { get; set; }

        public string Description { get; set; }

        public List<SubjectCurriculumSkill> SubjectCurriculums { get; set; }

        public Skill()
        {
            SubjectCurriculums = new List<SubjectCurriculumSkill>();
        }
    }
}