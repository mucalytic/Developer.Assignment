using Developer.Assignment.Application.Commands;
using FastEndpoints;
using MediatR;

namespace Developer.Assignment.Api.Endpoints.Products;

public class DeleteProductEndpoint(ISender sender) : Ep.Req<int>.NoRes
{
    public override void Configure()
    {
        Post("/api/product/delete/{productId:int}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(int productId, CancellationToken token)
    {
        var result = await sender.Send(new DeleteProductCommand(productId), token);
        if (result.IsSuccess)
        {
            await Send.OkAsync(token);
        }
        else
        {
            await Send.ErrorsAsync(400, token);
        }
    }
}
