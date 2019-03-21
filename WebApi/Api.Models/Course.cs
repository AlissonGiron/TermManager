using System.Collections.Generic;

namespace Api.Models
{
    public class Course: ModelBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Goal> Goals { get; set; }
        public List<Competence> Competences { get; set; }
        public List<Skill> Skills { get; set; }
        public List<User> Coordinators { get; set; }
        public List<User> TeachersNDE { get; set; }
    }
}