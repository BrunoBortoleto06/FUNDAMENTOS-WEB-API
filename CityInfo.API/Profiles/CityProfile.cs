using AutoMapper;
using CityInfo.API.Entities;

namespace CityInfo.API.Profiles
{
    public class CityProfile : Profile
    {

        public CityProfile()
        {
            CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDTO>();
            CreateMap<Entities.City, Models.CityDTO>();
        }

    }
}
