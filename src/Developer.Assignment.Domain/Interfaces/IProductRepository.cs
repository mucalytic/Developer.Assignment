using Developer.Assignment.Domain.Models;
using FluentResults;

namespace Developer.Assignment.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Result<Product>>      GetByIdAsync(int id);
    Task<int>                  CreateAsync(Product product);
    Task<int>                  UpdateAsync(Product product);
    Task<int>                  DeleteAsync(int id);
}
