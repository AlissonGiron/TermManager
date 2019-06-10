using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class ClassPlanController : Controller<ClassPlan>
    {
        public ClassPlanController(IClassPlanService service) : base(service) { } 
    }
}
