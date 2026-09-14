# LaunchpadCoreApis.WeatherSample

NuGet showcase for **[Nabs.Launchpad.Core.Apis](https://www.nuget.org/packages/Nabs.Launchpad.Core.Apis/10.0.273)** (`10.0.273`) — one endpoint class per route, registered with a single `MapNabsEndpoints` call.

## Package

```bash
dotnet add package Nabs.Launchpad.Core.Apis --version 10.0.273
```

NuGet: https://www.nuget.org/packages/Nabs.Launchpad.Core.Apis/10.0.273

## How `MapNabsEndpoints` works

1. Implement an endpoint by subclassing `NabsEndpointBase` (or `NabsEndpointBase<TRequest, TResponse>` with `NabsNone` when there is no request/response body).
2. Declare the route, HTTP method(s), name, tags, and summary via `NabsEndpointOptions` in the constructor.
3. Override `HandleAsync` to return an `IResult`.
4. In `Program.cs`, call `app.MapNabsEndpoints<Program>();` — the package discovers concrete `INabsEndpoint` types in the marker assembly and maps them.

This sample’s endpoint lives in `Endpoints/GetWeatherForecastEndpoint.cs` and serves `GET /weatherforecast`.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download) (this sample targets `net10.0`; verified with SDK `10.0.401`)

## Run

```bash
dotnet restore
dotnet run --project LaunchpadCoreApis.WeatherSample.csproj
```

By default the template listens on the URLs in `Properties/launchSettings.json` (typically `https://localhost:7xxx` and `http://localhost:5xxx`).

OpenAPI (Development): `/openapi/v1.json`

## Example

```bash
curl -s http://localhost:5079/weatherforecast
```

Example response shape:

```json
[
  {
    "date": "2026-09-15",
    "temperatureC": 12,
    "temperatureF": 53,
    "summary": "Mild"
  }
]
```

(Port may differ — check the console output when the app starts.)

## Stack

- ASP.NET Core minimal hosting (`net10.0`)
- OpenAPI via `Microsoft.AspNetCore.OpenApi`
- `Nabs.Launchpad.Core.Apis` endpoint discovery
