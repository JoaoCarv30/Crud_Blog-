using Crud_Blog.Context;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Configurations.Database
{
public static class DatabaseConfiguration
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<CrudBlogContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        return services;
    }
}

}