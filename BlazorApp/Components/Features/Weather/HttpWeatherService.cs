using System.Net.Http.Json;

namespace BlazorApp.Components.Features.Weather;

public class HttpWeatherService(HttpClient httpClient) : IWeatherService
{
    readonly HttpClient httpClient = httpClient;

    public async Task<WeatherForecast[]> GetForecastAsync() => 
        await httpClient.GetFromJsonAsync<WeatherForecast[]>("/weather") ?? [];
}
