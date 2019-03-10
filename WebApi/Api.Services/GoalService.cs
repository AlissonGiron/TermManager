using Api.Infrastructure;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class GoalService : ServiceBase, IGoalService
    {
        public GoalService(Context context) : base(context) {}
    }
}