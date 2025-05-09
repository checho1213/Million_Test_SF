namespace Million.Infraestructure.DependencyInjection;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<MillionMongoContext>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();
        return services;
    }
}
