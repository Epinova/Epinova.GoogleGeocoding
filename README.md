# Epinova.GoogleGeocoding
Epinova's take on Google Geocoding API

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Epinova.GoogleGeocoding&metric=alert_status)](https://sonarcloud.io/dashboard?id=Epinova.GoogleGeocoding)
[![Build status](https://ci.appveyor.com/api/projects/status/p885ysgt6kdm8isg/branch/master?svg=true)](https://ci.appveyor.com/project/Epinova_AppVeyor_Team/epinova-googlegeocoding/branch/master)
![Tests](https://img.shields.io/appveyor/tests/Epinova_AppVeyor_Team/epinova-googlegeocoding.svg)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)


## Usage

### Configuration

No configuration via config files are needed. All API calls are made towards Google's production endpoint.
Each service method in this API wrapper takes in an API key, so it is the calling application that decides how to configure that.

### Add registry to IoC container

If using Structuremap:
```csharp
    container.Configure(
        x =>
        {
            x.Scan(y =>
            {
                y.TheCallingAssembly();
                y.WithDefaultConventions();
            });

            x.AddRegistry<Epinova.GoogleGeocoding.GeocodingRegistry>();
        });
```

If you cannot use the [structuremap registry](src/GeocodingRegistry.cs) provided with this module,
you can manually set up [GeocodingService](src/GeocodingService.cs) for [IGeocodingService](src/IGeocodingService.cs).

### Inject contract and use service

[Epinova.GoogleGeocoding.IGeocodingService](src/IGeocodingService.cs) describes the service.

Basically, you can fetch geocoding info by a full address string, or by postalcode+country. This last one can be tricky without a good geocoding service API.

### Prerequisites

* [EPiServer.Framework](http://www.episerver.com/web-content-management) >= v11.1 for logging purposes.
* [Automapper](https://github.com/AutoMapper/AutoMapper) >= v8.0 for mapping models.
* [StructureMap](http://structuremap.github.io/) >= v4.7 for registering service contract.

### Installing

The module is published on nuget.org.

```bat
nuget install Epinova.GoogleGeocoding
```

## Built With

* .Net Framework 4.6.2

## Authors

* **Tarjei Olsen** - *Initial work* - [apeneve](https://github.com/apeneve)

See also the list of [contributors](https://github.com/Epinova/Epinova.GoogleGeocoding/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details

## Further reading

[Geocoding API Developer Guide](https://developers.google.com/maps/documentation/geocoding/intro)