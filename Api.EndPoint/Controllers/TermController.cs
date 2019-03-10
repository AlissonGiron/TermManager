using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class TermController : Controller<Term>
    {
        public TermController(ITermService service): base(service) { }
    }
}
