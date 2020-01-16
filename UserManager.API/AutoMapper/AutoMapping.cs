using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManager.API.Models;
using UserManager.Domain.Entities;

namespace UserManager.API.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User,UserViewModel>();
        }
    }
}
