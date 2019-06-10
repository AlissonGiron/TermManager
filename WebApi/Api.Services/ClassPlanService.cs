using Api.Infrastructure;
using Api.Interfaces;

namespace Api.Services
{
    public class ClassPlanService : ServiceBase, IClassPlanService
    {
        public ClassPlanService(Context context) : base(context) { }
    }
}
