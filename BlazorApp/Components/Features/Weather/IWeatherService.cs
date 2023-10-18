namespace BlazorApp.Components.Features.Weather;

public interface IWeatherService
{
    Task<WeatherForecast[]> GetForecastAsync();
}
