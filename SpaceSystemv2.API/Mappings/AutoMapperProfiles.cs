using AutoMapper;
using SpaceSystemv2.API.DTO;
using SpaceSystemv2.Domain;

namespace SpaceSystemv2.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateAstronautRequest, Astronaut>().ReverseMap();
            CreateMap<Astronaut, AstronautDto>().ReverseMap();
            CreateMap<UpdateAstronautDto, Astronaut>().ReverseMap();


        }
    }
}
