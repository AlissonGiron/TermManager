using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;
using Api.Infrastructure.Helpers;
using System.Linq;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class SubjectController : Controller<Subject>
    {
        public SubjectController(ISubjectService service): base(service) { }

        [HttpGet("SubjectProfessors/{id}")]
        public virtual IActionResult ReadProfessors(int id) => Read(new Query<User>().Filter(s => s.Professor || (id > 0 ? s.Id == id : false)).Track(false));
    }
}
