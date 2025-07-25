using Developer.Assignment.Domain.Interfaces;
using Developer.Assignment.Domain.Models;
using FluentResults;
using MediatR;

namespace Developer.Assignment.Application.Queries;

public class GetProductQueryHandler(IProductRepository repository) : IRequestHandler<GetProductQuery, Result<Product>>
{
    public async Task<Result<Product>> Handle(GetProductQuery query, CancellationToken token)
    {
        var result = await repository.GetByIdAsync(query.ProductId);
        return result;
    }
}