namespace Crud_Blog.Configurations.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program)); 
            return services;
        }
        
    }
}