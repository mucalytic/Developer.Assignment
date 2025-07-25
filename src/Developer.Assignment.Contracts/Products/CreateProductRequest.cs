using Developer.Assignment.Contracts.Dtos;

namespace Developer.Assignment.Contracts.Products;

public record CreateProductRequest(string Name, decimal Price, string Description);
