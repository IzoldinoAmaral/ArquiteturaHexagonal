using Serilog.Core;
using Serilog.Events;

namespace hexagonal.API.Modules;

/// <summary>
///  ApplicationDetailsEnricher
/// </summary>
public class ApplicationDetailsEnricher : ILogEventEnricher
{
    /// <summary>
    ///  Enrich
    /// </summary>
    /// <param name="propertyFactory"></param>
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        var applicationAssembly = Assembly.GetEntryAssembly();

        var name = applicationAssembly?.GetName().Name;
        var version = applicationAssembly?.GetName().Version;

        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ApplicationName", name));
        logEvent.AddPropertyIfAbsent(
            propertyFactory.CreateProperty("ApplicationVersion", version));
    }
}