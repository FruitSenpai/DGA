using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Users;
using WebApi.Models.Farms;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<Farm, FarmModel>();
            CreateMap<FarmModel, Farm>();
        }
    }
}