using System.Collections.Generic;

namespace Api.Models
{
    public class Term: ModelBase
    {
        public int SemesterNumber { get; set; }
        public int Year { get; set; }

        public List<TermCourse> Courses { get; set; }
    }
}