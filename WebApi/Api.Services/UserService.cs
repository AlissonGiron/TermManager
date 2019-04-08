using Api.Infrastructure;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System;

namespace Api.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private UserManager<User> _userManager;

        public UserService(Context context, UserManager<User> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public override void Create<T>(T entity)
        {
            User user = (User)(object)entity;
            IdentityResult result = _userManager.CreateAsync(user, user.Password).Result;

            if (!result.Succeeded)
            {
                throw new Exception(GetErrors(result));
            }
        }

        public override void Edit<T>(T entity)
        {
            User user = (User)(object)entity;
            IdentityResult result = _userManager.UpdateAsync(user).Result;

            if (!result.Succeeded)
            {
                throw new Exception(GetErrors(result));
            }
        }

        public override void Delete<T>(T entity)
        {
            User user = (User)(object)entity;
            IdentityResult result = _userManager.DeleteAsync(user).Result;

            if (!result.Succeeded)
            {
                throw new Exception(GetErrors(result));
            }
        }

        private string GetErrors(IdentityResult result)
        {
            return String.Join(Environment.NewLine, result.Errors.Select(e => $"{e.Code}: {e.Description}"));
        }
    }
}