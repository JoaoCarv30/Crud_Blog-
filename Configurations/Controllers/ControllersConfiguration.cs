namespace Crud_Blog.Configurations.Controllers
{
    public static class ControllersConfiguration
    {
         
        public static IServiceCollection AddControllersConfiguration(this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                });
            
            return services;
        }
    }
}