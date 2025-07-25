using Developer.Assignment.Contacts.Products;
using Developer.Assignment.Domain.Interfaces;
using Developer.Assignment.Api.Extensions;
using FastEndpoints;

namespace Developer.Assignment.Api.Endpoints.Products;

public class GetAllProductsEndpoint(IProductRepository repository) : Ep.NoReq.Res<ProductsResponse>
{
    public override void Configure()
    {
        Get("/api/products");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken token)
    {
        var products = await repository.GetAllAsync();
        await Send.OkAsync(new ProductsResponse(products.Select(p => p.ToDto()).ToList()), token);
    }
}
