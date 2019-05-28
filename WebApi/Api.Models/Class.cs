namespace Api.Models
{
    public class Class: ModelBase
    {
        public string Code { get; set; }
        public string Period { get; set; }

        public int IdProfessor { get; set; }
        public User Professor { get; set; }

        public int IdCourse { get; set; }
        public Course Course { get; set; }

        public int IdSubject { get; set; }
        public Subject Subject { get; set; }

        public int SemesterNumber { get; set; }

        public int Year { get; set; }
    }
}