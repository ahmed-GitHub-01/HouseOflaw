using AutoMapper;
using HouseOflaw.API.Dtos;
using HouseOflaw.API.Models;

namespace HouseOflaw.API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();
        }
    }
}