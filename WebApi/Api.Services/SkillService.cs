using Api.Infrastructure;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class SkillService : ServiceBase, ISkillService
    {
        public SkillService(Context context) : base(context) {}
    }
}