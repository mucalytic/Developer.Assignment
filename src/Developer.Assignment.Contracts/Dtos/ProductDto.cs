namespace Developer.Assignment.Contracts.Dtos;

public record ProductDto(
    int     Id,
    string  Name,
    decimal Price,
    string  Description
);
