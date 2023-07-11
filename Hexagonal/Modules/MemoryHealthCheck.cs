using System.Threading;

namespace hexagonal.API.Modules;

/// <summary>
/// MemoryHealthCheck
/// </summary>
public class MemoryHealthCheck : IHealthCheck
{
    private readonly IOptionsMonitor<MemoryCheckOptions> _options;

    /// <summary>
    /// MemoryHealthCheck
    /// </summary>
    /// <param name="options"></param>
    public MemoryHealthCheck(IOptionsMonitor<MemoryCheckOptions> options)
    {
        _options = options;
    }

    public string Name => "memory_check";

    /// <summary>
    /// MemoryHealthCheck
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        var options = _options.Get(context.Registration.Name);

        var allocated = GC.GetTotalMemory(false);
        var data = new Dictionary<string, object>
        {
            {"AllocatedBytes", allocated},
            {"Gen0Collections", GC.CollectionCount(0)},
            {"Gen1Collections", GC.CollectionCount(1)},
            {"Gen2Collections", GC.CollectionCount(2)}
        };
        var status = allocated < options.Threshold
            ? HealthStatus.Healthy
            : context.Registration.FailureStatus;

        return Task.FromResult(new HealthCheckResult(
            status,
            "Reports degraded status if allocated bytes " +
            $">= {options.Threshold} bytes.",
            null,
            data));
    }
}

/// <summary>
/// MemoryCheckOptions
/// </summary>
public class MemoryCheckOptions
{
    public long Threshold { get; set; } = 1024L * 1024L * 1024L;
}