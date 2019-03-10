using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class SkillController : Controller<Skill>
    {
        public SkillController(ISkillService service): base(service) { }
    }
}
