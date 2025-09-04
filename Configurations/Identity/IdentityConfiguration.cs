using Crud_Blog.Context;
using Crud_Blog.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Crud_Blog.Configurations.Identity
{
public static class IdentityConfiguration
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
    {
        services.AddIdentity<User, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<CrudBlogContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}
}