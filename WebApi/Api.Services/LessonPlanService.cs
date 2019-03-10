using Api.Infrastructure;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class LessonPlanService : ServiceBase, ILessonPlanService
    {
        public LessonPlanService(Context context) : base(context) {}
    }
}