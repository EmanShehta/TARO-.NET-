using AutoMapper;
using Core.MappingProfiles;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Taro.API.Errors;
using Taro.API.ExtenshionMethods;
using Taro.API.ExtensionMethods;
using Taro.Core.Interfaces;
using Taro.Repository.Context;
using Taro.Services.Implementation;
using Taro.Services.NewFolder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerServices();
builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddHttpClient();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});
builder.Services.AddScoped<ICourseServices,CourseServices>();
builder.Services.AddScoped<IVideoServices,VideoServices>();
builder.Services.AddAutoMapper(typeof(GeneralMappingProfile));


builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();

    });

});
var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();

try
{
    var identityContext = services.GetRequiredService<AppDbContext>();
    await identityContext.Database.MigrateAsync();

}
catch (Exception ex)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(ex, ex.Message);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors("CorsPolicy");
app.UseStatusCodePagesWithRedirects("/errors/{0}");

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
