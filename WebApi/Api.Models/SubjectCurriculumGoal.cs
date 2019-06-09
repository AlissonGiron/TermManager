using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Models
{
    public class SubjectCurriculumGoal: ModelBase
    {
        public int IdSubjectCurriculum { get; set; }
        public SubjectCurriculum SubjectCurriculum { get; set; }

        public int IdGoal { get; set; }
        public Goal Goal { get; set; }
    }
}
