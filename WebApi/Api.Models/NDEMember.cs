using System.Collections.Generic;

namespace Api.Models
{
    public class NDEMember : ModelBase
    {
        public int IdCourse { get; set; }
        public Course Course { get; set; }

        public string Description { get; set; }

        public List<SubjectCurriculumNDEMember> SubjectCurriculums { get; set; }

        public NDEMember()
        {
            SubjectCurriculums = new List<SubjectCurriculumNDEMember>();
        }
    }
}