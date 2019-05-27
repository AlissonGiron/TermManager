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

        public List<CourseUser> Users { get; set; }
        public List<CourseSubject> Subjects { get; set; }
        public List<TermCourse> Terms { get; set; }
        public List<NDEMember> NDEMembers { get; set; }
        public List<Book> Books { get; set; }
    }
}