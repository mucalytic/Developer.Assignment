using Developer.Assignment.Application.Queries;
using Developer.Assignment.Contacts.Products;
using Developer.Assignment.Api.Extensions;
using FastEndpoints;
using MediatR;

namespace Developer.Assignment.Api.Endpoints.Products;

public class GetProductByIdEndpoint(ISender sender) : Ep.Req<int>.Res<ProductResponse>
{
    public override void Configure()
    {
        Get("/api/product/{productId:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(int productId, CancellationToken token)
    {
        var result = await sender.Send(new GetProductQuery(productId), token);
        if (result.IsSuccess)
        {
            await Send.OkAsync(new ProductResponse(result.Value.ToDto()), token);
        }
        else
        {
            await Send.ErrorsAsync(400, token);
        }
    }
}
