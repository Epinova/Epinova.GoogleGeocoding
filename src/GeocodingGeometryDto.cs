using Newtonsoft.Json;

namespace Epinova.GoogleGeocoding
{
    internal class GeocodingGeometryDto
    {
        public GeocodingLocationDto Location { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }
    }
}