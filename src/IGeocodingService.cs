using System.Threading.Tasks;

namespace Epinova.GoogleGeocoding
{
    public interface IGeocodingService
    {
        /// <summary>
        /// Get geocoding info by postal code and country combination
        /// </summary>
        /// <param name="apiKey">Your API key to use in the calls towards Google</param>
        /// <param name="postalCode">Postal code (zip)</param>
        /// <param name="country">Country to look in</param>
        /// <param name="region">The region code, specified as a "top-level domain" two-character value.</param>
        /// <returns>The first matching geocoding info set</returns>
        Task<GeocodingInfo> GetGeocodingInfoAsync(string apiKey, string postalCode, string country, string region);

        /// <summary>
        /// Get geocoding info by address string
        /// </summary>
        /// <param name="apiKey">Your API key to use in the calls towards Google</param>
        /// <param name="address">The address string to search for</param>
        /// <param name="region">The region code, specified as a "top-level domain" two-character value.</param>
        /// <returns>The first matching geocoding info set</returns>
        Task<GeocodingInfo> GetGeocodingInfoAsync(string apiKey, string address, string region);
    }
}