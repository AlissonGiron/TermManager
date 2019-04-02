namespace Api.Models
{
    public class Skill: ModelBase
    {
        public int IdCourse { get; set; }
        public Course Course { get; set; }

        public string Description { get; set; }
    }
}