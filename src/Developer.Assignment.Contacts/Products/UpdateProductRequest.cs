using Developer.Assignment.Contacts.Dtos;

namespace Developer.Assignment.Contacts.Products;

public record UpdateProductRequest(int Id, string Name, decimal Price, string Description);
