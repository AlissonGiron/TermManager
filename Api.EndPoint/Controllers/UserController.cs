using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class UserController : Controller<User>
    {
        public UserController(IUserService service): base(service) { }
    }
}
