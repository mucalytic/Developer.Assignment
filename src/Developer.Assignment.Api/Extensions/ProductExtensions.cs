using Developer.Assignment.Contracts.Dtos;
using Developer.Assignment.Domain.Models;

namespace Developer.Assignment.Api.Extensions;

public static class ProductExtensions
{
    public static ProductDto ToDto(this Product product) =>
        new(product.Id, product.Name, product.Price, product.Description);

    public static Product ToProduct(this ProductDto dto) =>
        new()
        {
            Id = dto.Id,
            Name = dto.Name,
            Price = dto.Price,
            Description = dto.Description
        };
}
