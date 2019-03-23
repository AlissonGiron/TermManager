using System.Collections.Generic;

namespace Api.Models
{
    public class CourseSubject: ModelBase
    {
        public int IdCourse { get; set; }
        public Course Course { get; set; }

        public int IdSubject { get; set; }
        public Subject Subject { get; set; }
    }
}
