# Epinova.GoogleGeocoding
Epinova's take on Google Geocoding API

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Epinova.GoogleGeocoding&metric=alert_status)](https://sonarcloud.io/dashboard?id=Epinova.GoogleGeocoding)
[![Build status](https://ci.appveyor.com/api/projects/status/p885ysgt6kdm8isg/branch/master?svg=true)](https://ci.appveyor.com/project/Epinova_AppVeyor_Team/epinova-googlegeocoding/branch/master)
![Tests](https://img.shields.io/appveyor/tests/Epinova_AppVeyor_Team/epinova-googlegeocoding.svg)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)


## Usage
### Add registry to Structuremap

```
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

### Inject contract and use service

Epinova.GoogleGeocoding.IGeocodingService describes the service. 