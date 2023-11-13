using Microsoft.AspNetCore.Mvc;
using Taro.API.Errors;
using Taro.Repository.Services;
using Taro.Services;

namespace Taro.API.ExtenshionMethods
{
    public static class ApplicationServiceExtention
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped(typeof(ITokenService), typeof(TokenService));
            services.AddScoped(typeof(IEmailSettings), typeof(EmailSettings));
            services.AddApiBehaviorOptions();
            services.AddHttpContextAccessor();

            return services;
        }

        public static void AddApiBehaviorOptions(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    var errorResponse = new ApiValidationErrorResponse { Errors = errors };
                    return new BadRequestObjectResult(errorResponse);
                };
            });


        }
    }
}
