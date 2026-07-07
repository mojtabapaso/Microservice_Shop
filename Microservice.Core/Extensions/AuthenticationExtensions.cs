using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Core.Extensions;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddKeyCloakExtensions(this IServiceCollection service)
    {
        service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        //TODO change later
        const string authority = "http://localhost:8080/realms/Shop";
        options.Authority = authority;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new()
        {
            ValidateAudience = false
        };
    });
        return service;
    }
}