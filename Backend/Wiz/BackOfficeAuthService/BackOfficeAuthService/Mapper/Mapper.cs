using AbstractModels;
using AutoMapper;
using BackOfficeAuthService.Models.DTO;
using BackOfficeAuthService.Models.Requests;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackOfficeAuthService.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, AuthDTO>();
            CreateMap<AuthDTO, User>();
            CreateMap<RegisterRequest, User>();
            CreateMap<User, RegisterRequest>();
        }
    }
}
