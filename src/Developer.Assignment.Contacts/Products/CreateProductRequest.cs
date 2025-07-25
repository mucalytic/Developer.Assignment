using Developer.Assignment.Contacts.Dtos;

namespace Developer.Assignment.Contacts.Products;

public record CreateProductRequest(string Name, decimal Price, string Description);
