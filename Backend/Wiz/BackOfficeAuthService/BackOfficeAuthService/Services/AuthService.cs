
using BackOfficeAuthService.Models.DTO;
using BackOfficeAuthService.Models.Requests;
using BackOfficeAuthService.Repos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeAuthService.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepo authRepo;
        public AuthService(IAuthRepo authRepo)
        {
            this.authRepo = authRepo;
        }
        public AuthDTO Login(string email, string password)
        {
            return authRepo.Login(email, password);
        }

        public AuthDTO Register(RegisterRequest registerRequest)
        {
            return authRepo.Register(registerRequest);
        }
    }
}
