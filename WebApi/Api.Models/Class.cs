namespace Api.Models
{
    public class Class: ModelBase
    {
        public string Code { get; set; }
        public string Period { get; set; }
        public string Number { get; set; }

        public int IdTermCourseSubject { get; set; }
        public TermCourseSubject TermCourseSubject { get; set; }

        public int IdProfessor { get; set; }
        public User Professor { get; set; }
    }
}