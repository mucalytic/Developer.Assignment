using Microsoft.Extensions.DependencyInjection;
using Developer.Assignment.Domain.Settings;
using Microsoft.Extensions.Options;

namespace Developer.Assignment.Infrastructure.Extensions;

public static class ServiceProviderExtensions
{
    public static string GetDatabaseConnectionString(this IServiceProvider provider) =>
        provider.GetRequiredService<IOptions<ConnectionStrings>>().Value.Database;
}