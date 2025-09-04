using Crud_Blog.Configurations;
using Crud_Blog.Configurations.AutoMapper;
using Crud_Blog.Configurations.Controllers;
using Crud_Blog.Configurations.Database;
using Crud_Blog.Configurations.Identity;
using Crud_Blog.Configurations.JWT;
using Crud_Blog.Configurations.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersConfiguration();
builder.Services.AddDependencyInjection();
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddIdentityConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddJwtConfiguration(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();