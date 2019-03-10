using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class SubjectController : Controller<Subject>
    {
        public SubjectController(ISubjectService service): base(service) { }
    }
}
