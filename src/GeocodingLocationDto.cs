using Newtonsoft.Json;

namespace Epinova.GoogleGeocoding
{
    internal class GeocodingLocationDto
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
}
