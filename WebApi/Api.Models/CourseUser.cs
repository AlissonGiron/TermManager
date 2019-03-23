using static Api.Models.Enums;

namespace Api.Models
{
    public class CourseUser: ModelBase
    {
        public int IdCourse { get; set; }
        public Course Course { get; set; }

        public int IdUser { get; set; }
        public User User { get; set; }

        public CourseUserType Type { get; set; }
    }
}
