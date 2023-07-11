using FluentValidation;
using HealthChecks.UI.Client;
using hexagonal.API.Modules;
using hexagonal.API.Modules.Common;
using hexagonal.API.Modules.Common.FeatureFlags;
using hexagonal.API.Modules.Common.Swagger;
using hexagonal.Domain.Extensions;
using Microsoft.AspNetCore.Identity;

namespace hexagonal.API;

/// <summary>
/// Startup.
/// </summary>
public sealed class Startup
{
    /// <summary>
    /// Startup constructor.
    /// </summary>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    /// <summary>
    /// Configure dependencies from application.
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddFeatureFlags(Configuration)
            .AddSqlServer(Configuration)
            .AddEntityRepository()
            .AddAuthentication(Configuration)
            .AddVersioning()
            .AddSwagger()
            .AddUseCases()
            .AddCustomControllers()
            .AddCustomCors()
            .AddProxy()
            .AddCustomDataProtection();

        services.AddAutoMapperSetup();
        services.AddLogging();
        services.AddHealthChecks().AddCheck<MemoryHealthCheck>("Memory");
       
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<HashingOptions>();
    }

    /// <summary>
    /// Configure http request pipeline.
    /// </summary>
    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env,
        IApiVersionDescriptionProvider provider)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/api/V1/CustomError")
                .UseHsts();
        }

        app
            .UseProxy(Configuration)
            .UseCustomCors()
            .UseCustomHttpMetrics()
            .UseRouting()
            .UseVersionedSwagger(provider, Configuration)
            .UseAuthentication()
            .UseAuthorization()
            .UseSerilogRequestLogging()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                endpoints.MapControllers();
            });
    }
}