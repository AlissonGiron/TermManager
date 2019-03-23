using System.Collections.Generic;

namespace Api.Models
{
    public class TermCourse : ModelBase
    {
        public int IdTerm { get; set; }
        public Term Term { get; set; }

        public int IdCourse { get; set; }
        public Course Course { get; set; }

        public List<TermCourseSubject> Subjects { get; set; }
    }
}