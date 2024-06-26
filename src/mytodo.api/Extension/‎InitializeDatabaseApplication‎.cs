using System.Diagnostics.CodeAnalysis;
using mytodo.ioc;

namespace mytodo.api.Extension;

[ExcludeFromCodeCoverage]
public static class InitializeDatabaseApplication
{
    public static async Task InitialiseDatabaseAsync(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<MytodoDbContextInitializer>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}