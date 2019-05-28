using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;
using Api.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    //[Authorize(Roles = "Coordinator")]
    public class ClassController : Controller<Class>
    {
        public ClassController(IClassService service): base(service) { }

        [HttpGet("CheckCodeExists/{id}/{code}")]
        public IActionResult CheckCodeExists(int id, string code) => Ok(_service.Count(new Query<Class>().Filter(s => s.Code == code && s.Id != id)) > 0);

        [HttpGet("ClassProfessors/{id}")]
        public virtual IActionResult ReadProfessors(int id) => Read(new Query<User>().Filter(s => s.Professor || (id > 0 ? s.Id == id : true)).Track(false));

        [HttpGet("ClassCourses/{id}")]
        public virtual IActionResult ReadCourses(int id) => Read(new Query<Course>().Filter(s => (id > 0 ? s.Id == id : true)).Track(false));

        [HttpGet("ClassSubjects/{idCourse}/{id}")]
        public virtual IActionResult ReadSubjects(int idCourse, int id) => Read(new Query<Subject>().Filter(s => (idCourse > 0 ? s.Courses.Any(v => v.IdCourse == idCourse) : true) && (id > 0 ? s.Id == id : true)).Track(false));
    }
}
