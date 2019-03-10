using Api.Infrastructure;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class TermService : ServiceBase, ITermService
    {
        public TermService(Context context) : base(context) {}
    }
}