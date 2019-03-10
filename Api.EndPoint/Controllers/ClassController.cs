using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class ClassController : Controller<Class>
    {
        public ClassController(IClassService service): base(service) { }
    }
}
