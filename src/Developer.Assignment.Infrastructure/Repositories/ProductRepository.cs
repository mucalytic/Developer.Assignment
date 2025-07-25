using Developer.Assignment.Domain.Interfaces;
using Developer.Assignment.Domain.Models;
using System.Data;
using Dapper;
using Npgsql;

namespace Developer.Assignment.Infrastructure.Repositories;

public class ProductRepository(NpgsqlConnection connection) : IProductRepository
{
    private readonly IDbConnection _connection = connection;

    public Task<IEnumerable<Product>> GetAllAsync() =>
        _connection.QueryAsync<Product>("SELECT * FROM Products");

    public Task<Product?> GetByIdAsync(int id) =>
        _connection.QuerySingleOrDefaultAsync<Product>("SELECT * FROM Products WHERE Id = @Id", new { Id = id });

    public Task<int> CreateAsync(Product product) =>
        _connection.QuerySingleAsync<int>("INSERT INTO Products (Name, Price, Description) VALUES (@Name, @Price, @Description) RETURNING Id", product);

    public Task UpdateAsync(Product product) =>
        _connection.ExecuteAsync("UPDATE Products SET Name = @Name, Price = @Price, Description = @Description WHERE Id = @Id", product);

    public Task DeleteAsync(int id) =>
        _connection.ExecuteAsync("DELETE FROM Products WHERE Id = @Id", new { Id = id });
}
