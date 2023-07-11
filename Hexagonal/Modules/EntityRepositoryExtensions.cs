using hexagonal.Data;

namespace hexagonal.API.Modules;

/// <summary>
/// Persistence Extensions.
/// </summary>
public static class EntityRepositoryExtensions
{
    /// <summary>
    /// Add Persistence dependencies varying on configuration.
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddEntityRepository(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}