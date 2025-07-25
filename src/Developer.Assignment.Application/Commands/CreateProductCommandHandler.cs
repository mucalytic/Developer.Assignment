using Developer.Assignment.Domain.Interfaces;
using Developer.Assignment.Domain.Models;
using FluentResults;
using MediatR;

namespace Developer.Assignment.Application.Commands;

public class CreateProductCommandHandler(IProductRepository repository) : IRequestHandler<CreateProductCommand, Result<Product>>
{
    public async Task<Result<Product>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var productId = await repository.CreateAsync(new Product
        {
            Name = command.Name,
            Price = command.Price,
            Description = command.Description
        });
        var result = await repository.GetByIdAsync(productId);
        return result;
    }
}