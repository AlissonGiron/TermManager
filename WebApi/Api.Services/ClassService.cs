using Api.Infrastructure;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class ClassService : ServiceBase, IClassService
    {
        public ClassService(Context context) : base(context) {}
    }
}