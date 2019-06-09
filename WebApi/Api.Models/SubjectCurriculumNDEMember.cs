
namespace Api.Models
{
    public class SubjectCurriculumNDEMember: ModelBase
    {
        public int IdSubjectCurriculum { get; set; }
        public SubjectCurriculum SubjectCurriculum { get; set; }

        public int IdNDEMember { get; set; }
        public NDEMember NDEMember { get; set; }
    }
}
