using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace Crud_Blog.Configurations.Swagger
{
public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddOpenApi();
        services.AddSwaggerGen();
        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });

        return app;
    }
}
}