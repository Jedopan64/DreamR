using AutoMapper;
using DreamRF.Data.Entities;
using DreamRF.Features;

namespace DreamRF.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}