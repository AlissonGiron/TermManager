using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;
using Api.Infrastructure.Helpers;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class UserController : Controller<User>
    {
        public UserController(IUserService service): base(service) { }

        [HttpGet("CheckUsernameExists/{id}/{username}")]
        public IActionResult CheckCodeExists(int id, string username) => Ok(_service.Count(new Query<User>().Filter(s => s.Name == username && s.Id != id)) > 0);

    }
}
