using Epinova.GoogleGeocoding;
using StructureMap;
using Xunit;
using Xunit.Abstractions;

namespace Epinova.GoogleGeocodingTests
{
    public class GeocodingRegistryTests
    {
        private readonly Container _container;
        private readonly ITestOutputHelper _output;

        public GeocodingRegistryTests(ITestOutputHelper output)
        {
            _output = output;
            _container = new Container(new TestableRegistry());
            _container.Configure(x => { x.AddRegistry(new GeocodingRegistry()); });
        }

        [Fact]
        public void AssertConfigurationIsValid()
        {
            _output.WriteLine(_container.WhatDoIHave());
            _container.AssertConfigurationIsValid();
        }

        [Fact]
        public void Getting_ITransactionalMessageService_ReturnsTransactionalMessageService()
        {
            var instance = _container.GetInstance<IGeocodingService>();

            Assert.IsType<GeocodingService>(instance);
        }
    }
}