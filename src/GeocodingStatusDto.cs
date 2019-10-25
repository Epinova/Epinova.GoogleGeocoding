namespace Epinova.GoogleGeocoding
{
    internal enum GeocodingStatusDto
    {
        Unknown = 0,
        OK,
        ZERO_RESULTS,
        OVER_DAILY_LIMIT,
        OVER_QUERY_LIMIT,
        REQUEST_DENIED,
        INVALID_REQUEST,
        UNKNOWN_ERROR
    }
}
