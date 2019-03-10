using Api.Infrastructure;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService(Context context) : base(context) {}
    }
}