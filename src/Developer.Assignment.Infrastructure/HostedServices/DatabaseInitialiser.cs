using Microsoft.Extensions.Hosting;
using System.Data;
using Dapper;
using Npgsql;

namespace Developer.Assignment.Infrastructure.HostedServices;

public class DatabaseInitialiser(NpgsqlConnection connection) : IHostedService
{
    private readonly IDbConnection _connection = connection;
    
    public Task StartAsync(CancellationToken cancellationToken) =>
        _connection.ExecuteAsync("""
                CREATE TABLE IF NOT EXISTS Products (
                    Id SERIAL PRIMARY KEY,
                    Name VARCHAR(100),
                    Price DECIMAL,
                    Description TEXT
                );
            """);

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}