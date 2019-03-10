using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class GoalController : Controller<Goal>
    {
        public GoalController(IGoalService service): base(service) { }
    }
}
