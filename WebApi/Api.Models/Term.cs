using System.Collections.Generic;

namespace Api.Models
{
    public class Term: ModelBase
    {
        public string SchoolYear { get; set; }
        public int IdCourse { get; set; }
        public int SemesterNumber { get; set; }

        // TODO: n pra n
        public List<Subject> Subjects { get; set; }
    }
}