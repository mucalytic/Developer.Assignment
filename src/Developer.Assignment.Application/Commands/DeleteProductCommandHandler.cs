using Developer.Assignment.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace Developer.Assignment.Application.Commands;

public class DeleteProductCommandHandler(IProductRepository repository) : IRequestHandler<DeleteProductCommand, Result<Unit>>
{
    public async Task<Result<Unit>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var count = await repository.DeleteAsync(command.ProductId);
        return count == 1 ? Result.Ok(Unit.Value) : Result.Fail<Unit>("Product not deleted");
    }
}