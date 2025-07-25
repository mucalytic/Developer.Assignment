using Developer.Assignment.Contracts.Dtos;

namespace Developer.Assignment.Contracts.Products;

public record UpdateProductRequest(int Id, string Name, decimal Price, string Description);
