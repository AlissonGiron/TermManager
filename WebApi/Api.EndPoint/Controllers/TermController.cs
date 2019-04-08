using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;
using Api.Infrastructure.Helpers;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class TermController : Controller<Term>
    {
        public TermController(ITermService service): base(service) { }

        [HttpGet("CheckTermExists/{id}/{year}/{number}")]
        public IActionResult CheckTermExists(int id, int year, int number) => Ok(_service.Count(new Query<Term>().Filter(s => s.SemesterNumber == number && s.Year == year && s.Id != id)) > 0);
    }
}
