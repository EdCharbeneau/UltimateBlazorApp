using AutoFixture;
using AutoFixture.Xunit2;

namespace BlazorApp.Autofixture;
public class DateOnlyFixture
{
    public static Fixture Create()
    {
        var fixture = new Fixture();
        fixture.Customize<DateOnly>(composer => composer.FromFactory<DateTime>(DateOnly.FromDateTime));
        return fixture;
    }
}

/// <summary>
/// Adds dotnet 7 DateOnly struct support for Autodata.
/// See: https://stackoverflow.com/questions/73732174/does-autofixture-support-dateonly-for-net6
/// </summary>
public class AutoDataDateCompatibilityAttribute : AutoDataAttribute
{
    public AutoDataDateCompatibilityAttribute()
      : base(() => DateOnlyFixture.Create())
    { }
}
