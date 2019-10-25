using AutoMapper;
using StructureMap;

namespace Epinova.GoogleGeocoding
{
    public class GeocodingRegistry : Registry
    {
        public GeocodingRegistry()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new GeocodingMappingProfile()); });
            mapperConfiguration.CompileMappings();

            For<IGeocodingService>().Use<GeocodingService>().Ctor<IMapper>().Is(mapperConfiguration.CreateMapper());
        }
    }
}
