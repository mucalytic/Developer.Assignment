using Developer.Assignment.Domain.Interfaces;
using Developer.Assignment.Domain.Models;
using System.Data;
using Dapper;
using FluentResults;
using Npgsql;

namespace Developer.Assignment.Infrastructure.Repositories;

public class ProductRepository(NpgsqlConnection connection) : IProductRepository
{
    private readonly IDbConnection _connection = connection;

    public Task<IEnumerable<Product>> GetAllAsync() =>
        _connection.QueryAsync<Product>("SELECT * FROM Products");

    public async Task<Result<Product>> GetByIdAsync(int id)
    {
        var product = await _connection.QuerySingleOrDefaultAsync<Product>("SELECT * FROM Products WHERE Id = @Id", new { Id = id });
        return product is null ? Result.Fail<Product>("Product not found") : Result.Ok(product);
    }

    public Task<int> CreateAsync(Product product) =>
        _connection.QuerySingleAsync<int>("INSERT INTO Products (Name, Price, Description) VALUES (@Name, @Price, @Description) RETURNING Id", product);

    public Task<int> UpdateAsync(Product product) =>
        _connection.ExecuteAsync("UPDATE Products SET Name = @Name, Price = @Price, Description = @Description WHERE Id = @Id", product);

    public Task<int> DeleteAsync(int id) =>
        _connection.ExecuteAsync("DELETE FROM Products WHERE Id = @Id", new { Id = id });
}
