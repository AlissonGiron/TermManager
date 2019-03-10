using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class LessonPlanController : Controller<LessonPlan>
    {
        public LessonPlanController(ILessonPlanService service): base(service) { }
    }
}
