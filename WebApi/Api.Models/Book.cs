using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Models
{
    public class Book : ModelBase
    {
        public int IdCourse { get; set; }
        public Course Course { get; set; }

        public string Description { get; set; }

        public ICollection<ClassPlanBookItem> BookItems { get; set; }

        public List<SubjectCurriculumBook> SubjectCurriculums { get; set; }

        public Book()
        {
            SubjectCurriculums = new List<SubjectCurriculumBook>();
        }
    }
}
