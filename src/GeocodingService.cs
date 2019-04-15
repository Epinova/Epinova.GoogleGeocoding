﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Epinova.Infrastructure;
using Epinova.Infrastructure.Logging;
using EPiServer.Logging;

namespace Epinova.GoogleGeocoding
{
    internal class GeocodingService : RestServiceBase, IGeocodingService
    {
        internal static HttpClient Client;
        private readonly ILogger _log;
        private readonly IMapper _mapper;


        static GeocodingService()
        {
            Client = new HttpClient { BaseAddress = new Uri("https://maps.googleapis.com/maps/api/geocode/json") };
        }

        public GeocodingService(ILogger log, IMapper mapper) : base(log)
        {
            _log = log;
            _mapper = mapper;
        }

        public override string ServiceName => nameof(GeocodingService);

        public async Task<GeocodingInfo> GetGeocodingInfoAsync(string apiKey, string postalCode, string country)
        {
            return await GetGeocodingInfoAsync(apiKey, String.Join(", ", postalCode, country)).ConfigureAwait(false);
        }

        public async Task<GeocodingInfo> GetGeocodingInfoAsync(string apiKey, string address)
        {
            var parameters = new SortedDictionary<string, string>
            {
                { "address", address },
                { "region", "no"},
                { "key", apiKey },
            };
            string url = $"?{BuildQueryString(parameters)}";

            HttpResponseMessage responseMessage = await Call(() => Client.GetAsync(url), true).ConfigureAwait(false);
            if (responseMessage?.StatusCode != HttpStatusCode.OK)
            {
                _log.Error($"Geocoding query failed. Service response was NULL or status code not OK for address {address}.");
                return null;
            }

            GeocodingRootDto resultDto = await ParseJson<GeocodingRootDto>(responseMessage).ConfigureAwait(false);

            if (resultDto.Status != GeocodingStatusDto.OK || resultDto.HasError || resultDto.Results == null || !resultDto.Results.Any())
            {
                _log.Error(new { message = "Geocoding query failed", resultDto });
                return null;
            }

            return _mapper.Map<GeocodingInfo>(resultDto.Results.First());
        }
    }
}