using AutoMapper;

namespace Epinova.GoogleGeocoding
{
    public class GeocodingMappingProfile : Profile
    {
        public GeocodingMappingProfile()
        {
            AllowNullCollections = false;
            CreateMap<GeocodingResultDto, GeocodingInfo>()
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Geometry.Location.Latitude))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Geometry.Location.Longitude));
        }
    }
}
