using Api.Infrastructure;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class SubjectService : ServiceBase, ISubjectService
    {
        public SubjectService(Context context) : base(context) {}
    }
}