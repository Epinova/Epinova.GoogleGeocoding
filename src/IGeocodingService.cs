using System.Threading.Tasks;

namespace Epinova.GoogleGeocoding
{
    public interface IGeocodingService
    {
        Task<GeocodingInfo> GetGeocodingInfoAsync(string apiKey, string postalCode, string country);
        Task<GeocodingInfo> GetGeocodingInfoAsync(string apiKey, string address);
    }
}