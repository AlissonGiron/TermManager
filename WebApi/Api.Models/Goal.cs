namespace Api.Models
{
    public class Goal: ModelBase
    {
        public int IdCourse { get; set; }
        public Course Course { get; set; }

        public string Description { get; set; }
    }
}