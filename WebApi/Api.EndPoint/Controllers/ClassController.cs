using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;
using Api.Infrastructure.Helpers;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class ClassController : Controller<Class>
    {
        public ClassController(IClassService service): base(service) { }

        [HttpGet("CheckCodeExists/{id}/{code}")]
        public IActionResult CheckCodeExists(int id, string code) => Ok(_service.Count(new Query<Class>().Filter(s => s.Code == code && s.Id != id)) > 0);

        [HttpGet("ClassProfessors/{id}")]
        public virtual IActionResult ReadProfessors(int id) => Read(new Query<User>().Filter(s => s.Professor || (id > 0 ? s.Id == id : false)).Track(false));

    }
}
