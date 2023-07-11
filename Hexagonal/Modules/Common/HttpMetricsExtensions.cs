namespace hexagonal.API.Modules.Common;

/// <summary>
/// Http Metrics Extensions.
/// </summary>
public static class HttpMetricsExtensions
{
    /// <summary>
    /// Add Prometheus dependencies.
    /// </summary>
    /// <param name="appBuilder"></param>
    public static IApplicationBuilder UseCustomHttpMetrics(this IApplicationBuilder appBuilder)
    {
        return appBuilder;
    }
}