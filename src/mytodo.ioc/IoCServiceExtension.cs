using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mytodo.data;
using mytodo.domain.Services;
using mytodo.ioc.Services;

namespace mytodo.ioc;

public static class IoCServiceExtension
{
    public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureDbContext(services, configuration);
        services.AddScoped<IEncryptionService, EncryptionService>();
    }

    private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MytodoDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("MytodoDbContext"));
        });

        services.AddScoped<InitializeDatabaseApplication>();
    }
}