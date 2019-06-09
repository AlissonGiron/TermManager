using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Models
{
    public class SubjectCurriculumCompetence: ModelBase
    {
        public int IdSubjectCurriculum { get; set; }
        public SubjectCurriculum SubjectCurriculum { get; set; }

        public int IdCompetence { get; set; }
        public Competence Competence { get; set; }
    }
}
