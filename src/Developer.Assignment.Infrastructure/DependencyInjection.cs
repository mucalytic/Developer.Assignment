using Developer.Assignment.Infrastructure.HostedServices;
using Developer.Assignment.Infrastructure.Repositories;
using Developer.Assignment.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Developer.Assignment.Domain.Interfaces;
using Npgsql;

namespace Developer.Assignment.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository>(provider =>
            new ProductRepository(new NpgsqlConnection(provider.GetDatabaseConnectionString())));
        services.AddHostedService<DatabaseInitialiser>(provider =>
            new DatabaseInitialiser(new NpgsqlConnection(provider.GetDatabaseConnectionString())));
        return services;
    }
}
