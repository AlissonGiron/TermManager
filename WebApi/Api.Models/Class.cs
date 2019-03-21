namespace Api.Models
{
    public class Class: ModelBase
    {
        public string Code { get; set; }
        public string SemesterSubject { get; set; }
        public string Period { get; set; }
        public string ClassNumber { get; set; }

        public int IdTeacher { get; set; }
        public User Teacher { get; set; }
    }
}