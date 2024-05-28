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
        // Configurando contexto
        ConfigureDbContext(services, configuration);
        // Configurando mediator
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        // Injeções de Dependência
        services.AddScoped<IEncryptionService, EncryptionService>();
    }

    private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MytodoDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            options.UseMySql(connectionString, serverVersion);
        });
        services.AddScoped<MytodoDbContextInitializer>();
    }
}