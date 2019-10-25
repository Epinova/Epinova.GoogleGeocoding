using AutoMapper;
using Epinova.GoogleGeocoding;
using Xunit;

namespace Epinova.GoogleGeocodingTests
{
    public class GeocodingMappingProfileTests
    {
        [Fact]
        public void AllowNullCollections_IsFalse()
        {
            var profile = new GeocodingMappingProfile();
            Assert.False(profile.AllowNullCollections);
        }

        [Fact]
        public void AutoMapperConfiguration_IsValid()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<GeocodingMappingProfile>(); });

            config.AssertConfigurationIsValid();
        }

        [Fact]
        public void Map_GeocodingResultDto_FormattedAddress()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<GeocodingMappingProfile>(); });
            IMapper mapper = config.CreateMapper();

            var dto = new GeocodingResultDto { FormattedAddress = Factory.GetString() };
            var result = mapper.Map<GeocodingInfo>(dto);

            Assert.Equal(dto.FormattedAddress, result.FormattedAddress);
        }

        [Fact]
        public void Map_GeocodingResultDto_Latitude()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<GeocodingMappingProfile>(); });
            IMapper mapper = config.CreateMapper();

            var dto = new GeocodingResultDto { Geometry = new GeocodingGeometryDto { Location = new GeocodingLocationDto { Latitude = 13.37 } } };
            var result = mapper.Map<GeocodingInfo>(dto);

            Assert.Equal(dto.Geometry.Location.Latitude, result.Latitude);
        }

        [Fact]
        public void Map_GeocodingResultDto_Longitude()
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<GeocodingMappingProfile>(); });
            IMapper mapper = config.CreateMapper();

            var dto = new GeocodingResultDto { Geometry = new GeocodingGeometryDto { Location = new GeocodingLocationDto { Longitude = 13.37 } } };
            var result = mapper.Map<GeocodingInfo>(dto);

            Assert.Equal(dto.Geometry.Location.Longitude, result.Longitude);
        }
    }
}
