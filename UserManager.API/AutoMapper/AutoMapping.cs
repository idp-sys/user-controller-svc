using AutoMapper;
using UserManager.API.Models;
using UserManager.Domain.Entities;

namespace UserManager.API.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}