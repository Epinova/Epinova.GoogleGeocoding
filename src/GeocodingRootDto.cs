using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Epinova.GoogleGeocoding
{
    /// <summary>
    /// The result from google contains lots more than the properties defined here and in the other DTOs. I only included a minimum to avoid excess deserialization. --tarjei
    /// </summary>
    internal class GeocodingRootDto : ResponseDtoBase
    {
        public GeocodingResultDto[] Results { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public GeocodingStatusDto Status { get; set; }
    }
}
