using Developer.Assignment.Domain.Interfaces;
using Developer.Assignment.Domain.Models;
using FluentResults;
using MediatR;

namespace Developer.Assignment.Application.Commands;

public class UpdateProductCommandHandler(IProductRepository repository) : IRequestHandler<UpdateProductCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var count = await repository.UpdateAsync(new Product
        {
            Id = command.ProductId,
            Name = command.Name,
            Price = command.Price,
            Description = command.Description
        });
        return count == 1 ? Result.Ok(Unit.Value) : Result.Fail<Unit>("Product not updated");
    }
}