using BlazorApp.Components.Features.Weather;

namespace BlazorApp.Server;

public class ServerWeatherService : IWeatherService
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public Task<WeatherForecast[]> GetForecastAsync() => 
        Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast(default, default, null)
        {
            Date = DateOnly.FromDateTime(DateTime.Today).AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray());
}
