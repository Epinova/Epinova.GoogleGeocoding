using Newtonsoft.Json;

namespace Epinova.GoogleGeocoding
{
    internal class GeocodingResultDto
    {
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        public GeocodingGeometryDto Geometry { get; set; }
    }
}