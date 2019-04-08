using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Exemplo OU
    //[Authorize(Roles = "Administrator,Coordinator,Professor")]

    // Exemplo E
    //[Authorize(Roles = "Administrator")]
    //[Authorize(Roles = "Coordinator")]
    //[Authorize(Roles = "Professor")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private UserManager<User> _userManager;

        public LoginController(IConfiguration configuration, UserManager<User> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (user.UserName == null || user.Password == null)
            {
                return Unauthorized();
            }

            User dbUser = await _userManager.FindByNameAsync(user.UserName);

            if (dbUser == null || !await _userManager.CheckPasswordAsync(dbUser, user.Password))
            {
                return Unauthorized();
            }

            return Ok(new { token = GenerateSecurityToken(dbUser) });
        }

        private string GenerateSecurityToken(User user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            if (user.Administrator) claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
            if (user.Coordinator) claims.Add(new Claim(ClaimTypes.Role, "Coordinator"));
            if (user.Professor) claims.Add(new Claim(ClaimTypes.Role, "Professor"));

            SymmetricSecurityKey symKey = new SymmetricSecurityKey(key);
            SigningCredentials credentials = new SigningCredentials(symKey, SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = credentials,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(5),
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}