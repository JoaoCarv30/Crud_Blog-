using Crud_Blog.Generics;
using Crud_Blog.Repositories;
using Crud_Blog.Repositories.Interfaces;
using Crud_Blog.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Crud_Blog.Configurations
{
public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        // Repositórios genéricos
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        // Repositórios específicos
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();

        // Services
        services.AddScoped<PostService>();
        services.AddScoped<CommentService>();
        services.AddScoped<UserService>();
        services.AddScoped<AuthService>();


        return services;
    }
}
}