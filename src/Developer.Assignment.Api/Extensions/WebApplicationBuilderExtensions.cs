using Developer.Assignment.Domain.Settings;

namespace Developer.Assignment.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static IConfigurationSection GetConnectionStringsSection(this WebApplicationBuilder builder) =>
        builder.Configuration.GetSection(nameof(ConnectionStrings));
}
