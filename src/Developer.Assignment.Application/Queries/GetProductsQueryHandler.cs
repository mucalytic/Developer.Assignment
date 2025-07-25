using Developer.Assignment.Domain.Interfaces;
using Developer.Assignment.Domain.Models;
using MediatR;

namespace Developer.Assignment.Application.Queries;

public class GetProductsQueryHandler(IProductRepository repository) : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    public async Task<IEnumerable<Product>> Handle(GetProductsQuery _, CancellationToken token)
    {
        var result = await repository.GetAllAsync();
        return result;
    }
}