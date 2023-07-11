namespace hexagonal.API.Modules.Common;

/// <summary>
/// Data Protection Extensions.
/// </summary>
public static class DataProtectionExtensions
{
    /// <summary>
    /// Add Data Protection.
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddCustomDataProtection(this IServiceCollection services)
    {
        return services;
    }
}