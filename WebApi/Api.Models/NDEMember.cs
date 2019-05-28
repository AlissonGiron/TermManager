namespace Api.Models
{
    public class NDEMember : ModelBase
    {
        public int IdCourse { get; set; }
        public Course Course { get; set; }

        public string Description { get; set; }
    }
}