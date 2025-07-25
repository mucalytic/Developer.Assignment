using Developer.Assignment.Domain.Models;

namespace Developer.Assignment.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?>             GetByIdAsync(int id);
    Task<int>                  CreateAsync(Product product);
    Task                       UpdateAsync(Product product);
    Task                       DeleteAsync(int id);
}
