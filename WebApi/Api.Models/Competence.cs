using System.Collections.Generic;

namespace Api.Models
{
    public class Competence: ModelBase
    {
        public int IdCourse { get; set; }
        public Course Course { get; set; }

        public string Description { get; set; }

        public List<SubjectCurriculumCompetence> SubjectCurriculums { get; set; }

        public Competence()
        {
            SubjectCurriculums = new List<SubjectCurriculumCompetence>();
        }
    }
}