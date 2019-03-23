using System.Collections.Generic;

namespace Api.Models
{
    public class TermCourseSubject : ModelBase
    {
        public int IdTermCourse { get; set; }
        public TermCourse Term { get; set; }

        public int IdSubject { get; set; }
        public Subject Subject { get; set; }

        public List<Class> Classes { get; set; }
    }
}
