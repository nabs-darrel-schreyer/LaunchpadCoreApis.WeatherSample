using Nabs.Launchpad.Core.Apis;

namespace LaunchpadCoreApis.WeatherSample.Endpoints;

public sealed class GetWeatherForecastEndpoint : NabsEndpointBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild",
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public GetWeatherForecastEndpoint()
        : base(new NabsEndpointOptions("/weatherforecast", HttpMethod.Get)
        {
            EndpointName = "WeatherForecast",
            Tags = ["Weather"],
            Summary = "Get a 5-day weather forecast sample."
        })
    {
    }

    protected override Task<IResult> HandleAsync(HttpContext httpContext, CancellationToken cancellationToken)
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
        {
            var temperatureC = Random.Shared.Next(-20, 55);
            return new WeatherForecast(
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                temperatureC,
                32 + (int)(temperatureC / 0.5556),
                Summaries[Random.Shared.Next(Summaries.Length)]);
        }).ToArray();

        return Task.FromResult<IResult>(Results.Ok(forecast));
    }
}

public sealed record WeatherForecast(
    DateOnly Date,
    int TemperatureC,
    int TemperatureF,
    string? Summary);
