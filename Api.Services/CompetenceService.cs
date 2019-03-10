using Api.Infrastructure;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class CompetenceService : ServiceBase, ICompetenceService
    {
        public CompetenceService(Context context) : base(context) {}
    }
}