using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Epinova.GoogleGeocoding;
using EPiServer.Logging;
using Moq;
using Xunit;

namespace Epinova.GoogleGeocodingTests
{
    public partial class GeocodingServiceTests
    {
        private readonly Mock<ILogger> _logMock;
        private readonly TestableHttpMessageHandler _messageHandler;
        private readonly GeocodingService _service;

        public GeocodingServiceTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new GeocodingMappingProfile()); });
            _messageHandler = new TestableHttpMessageHandler();
            _logMock = new Mock<ILogger>();
            GeocodingService.Client = new HttpClient(_messageHandler) { BaseAddress = new Uri("https://fake.api.uri/") };
            _service = new GeocodingService(_logMock.Object, mapperConfiguration.CreateMapper());
        }


        [Fact]
        public async Task GetGeocodingInfo_InternalServerError_ReturnsNull()
        {
            _messageHandler.SendAsyncReturns(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            GeocodingInfo result = await _service.GetGeocodingInfoAsync(Factory.GetString(), Factory.GetString(), "no");

            Assert.Null(result);
        }

        [Fact]
        public async Task GetGeocodingInfo_Match_ReturnsCorrectAddress()
        {
            _messageHandler.SendAsyncReturns(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(GetValidPostalCodeResult())
            });
            GeocodingInfo result = await _service.GetGeocodingInfoAsync(Factory.GetString(), Factory.GetString(), "no");

            Assert.Equal("0672 Oslo, Norge", result.FormattedAddress);
        }

        [Fact]
        public async Task GetGeocodingInfo_Match_ReturnsCorrectLatitude()
        {
            _messageHandler.SendAsyncReturns(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(GetValidPostalCodeResult())
            });
            GeocodingInfo result = await _service.GetGeocodingInfoAsync(Factory.GetString(), Factory.GetString(), "no");

            Assert.Equal(59.9101185, result.Latitude);
        }

        [Fact]
        public async Task GetGeocodingInfo_Match_ReturnsCorrectLongitude()
        {
            _messageHandler.SendAsyncReturns(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(GetValidPostalCodeResult())
            });
            GeocodingInfo result = await _service.GetGeocodingInfoAsync(Factory.GetString(), Factory.GetString(), "no");

            Assert.Equal(10.8608624, result.Longitude);
        }

        [Fact]
        public async Task GetGeocodingInfo_Match_ReturnsCorrectResult()
        {
            _messageHandler.SendAsyncReturns(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(GetValidPostalCodeResult())
            });
            GeocodingInfo result = await _service.GetGeocodingInfoAsync(Factory.GetString(), Factory.GetString(), "no");

            Assert.IsType<GeocodingInfo>(result);
        }

        [Fact]
        public async Task GetGeocodingInfo_DtoStatusNotOk_ReturnsNull()
        {
            _messageHandler.SendAsyncReturns(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(GetInvaldResult())
            });
            GeocodingInfo result = await _service.GetGeocodingInfoAsync(Factory.GetString(), Factory.GetString(), "no");

            Assert.Null(result);
        }

        [Fact]
        public async Task GetGeocodingInfo_ParseResultFails_ReturnsNull()
        {
            _messageHandler.SendAsyncReturns(new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{ 'Some': 'random', 'un-parseable': 'json' }")
            });
            GeocodingInfo result = await _service.GetGeocodingInfoAsync(Factory.GetString(), Factory.GetString(), "no");

            Assert.Null(result);
        }

        [Fact]
        public async Task GetGeocodingInfo_ServiceReturnsNull_LogsError()
        {
            string apiKey = Factory.GetString();
            string address = Factory.GetString();
            _messageHandler.SendAsyncReturns(null);

            await _service.GetGeocodingInfoAsync(apiKey, address, "no");

            _logMock.VerifyLog(Level.Error, $"Geocoding query failed. Service response was NULL or status code not OK for address {address}.", Times.Once());
        }

        [Fact]
        public async Task GetGeocodingInfo_ServiceReturnsNull_ReturnsNull()
        {
            _messageHandler.SendAsyncReturns(null);
            GeocodingInfo result = await _service.GetGeocodingInfoAsync(Factory.GetString(), Factory.GetString(), "no");

            Assert.Null(result);
        }
    }
}