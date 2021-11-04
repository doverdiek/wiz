
using BackOfficeAuthService.Models.DTO;
using BackOfficeAuthService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson.IO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BackOfficeAuth;
using BackOfficeAuthService.Models.Requests;

namespace BackOfficeAuthService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public AuthDTO Login([FromBody]LoginRequest loginRequest)
        {
            var auth = authService.Login(loginRequest.Email, loginRequest.Password);
            if (auth != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(BackOfficeAuthentication.KEY);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.NameIdentifier, auth.Id),
                    new Claim(ClaimTypes.Name,auth.Email)
                    }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
               auth.Token = tokenHandler.WriteToken(token);
                return auth;
            }
            return null;
        }

        [HttpPost("register")]
        public AuthDTO Register([FromBody] RegisterRequest registerRequest)
        {
            AuthDTO auth = authService.Register(registerRequest);
            return auth;
        }
    }
}
