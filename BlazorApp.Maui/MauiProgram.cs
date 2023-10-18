using BlazorApp;
using BlazorApp.Maui.Helpers;
using Microsoft.Extensions.Logging;

namespace BlazorApp.Maui;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
        // If using localhost
        builder.Services.AddDevHttpClient(7066);
#else
            // If using a published development API instead of localhost
            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("Production API") });
#endif
        builder.Services.AddSingleton<IWeatherService, HttpWeatherService>();

        return builder.Build();
    }
}
