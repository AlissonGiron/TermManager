using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class CompetenceController : Controller<Competence>
    {
        public CompetenceController(ICompetenceService service): base(service) { }
    }
}
