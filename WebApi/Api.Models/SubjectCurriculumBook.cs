using System;
using System.Collections.Generic;
using System.Text;
using static Api.Models.Enums;

namespace Api.Models
{
    public class SubjectCurriculumBook: ModelBase
    {
        public int IdSubjectCurriculum { get; set; }
        public SubjectCurriculum SubjectCurriculum { get; set; }

        public int IdBook { get; set; }
        public Book Book { get; set; }

        public BibliographyType Type { get; set; }
    }
}
