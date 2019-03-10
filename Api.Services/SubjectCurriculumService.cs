using Api.Infrastructure;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class SubjectCurriculumService : ServiceBase, ISubjectCurriculumService
    {
        public SubjectCurriculumService(Context context) : base(context) {}
    }
}