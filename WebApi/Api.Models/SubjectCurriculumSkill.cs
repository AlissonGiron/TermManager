
namespace Api.Models
{
    public class SubjectCurriculumSkill: ModelBase
    {
        public int IdSubjectCurriculum { get; set; }
        public SubjectCurriculum SubjectCurriculum { get; set; }

        public int IdSkill { get; set; }
        public Skill Skill { get; set; }
    }
}
