using Microservice.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microservice.Core.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddSqlServer<TContext>(this IServiceCollection services, IConfiguration configuration)
                where TContext : DbContext, IUnitOfWork
    {
        services.AddDbContext<TContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TContext>());
        return services;
    }
}
