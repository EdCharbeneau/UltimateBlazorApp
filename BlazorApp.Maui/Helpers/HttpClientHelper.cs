namespace BlazorApp.Maui.Helpers;
public static class HttpClientHelper
{
    public static IServiceCollection AddDevHttpClient(this IServiceCollection services, int sslPort)
    {
#if ANDROID
        var handler = new Xamarin.Android.Net.AndroidMessageHandler();
        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
        {
            if (cert != null && cert.Issuer.Equals("CN=localhost"))
                return true;
            return errors == System.Net.Security.SslPolicyErrors.None;
        };
        var httpClient = new HttpClient(handler);
#elif IOS
        var handler = new NSUrlSessionHandler
        {
            TrustOverrideForUrl = (sender, url, trust) => url.StartsWith("https://localhost")
        };
        var httpClient = new HttpClient(handler);
#else
        var httpClient = new HttpClient();
#endif

#if ANDROID
        httpClient.BaseAddress = new Uri($"https://10.0.2.2:{sslPort}");
#else
        httpClient.BaseAddress = new Uri($"https://localhost:{sslPort}");
#endif
        return services.AddSingleton(httpClient);
    }
}
