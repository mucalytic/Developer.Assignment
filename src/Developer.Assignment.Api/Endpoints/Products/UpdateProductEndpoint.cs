using Developer.Assignment.Application.Commands;
using Developer.Assignment.Contracts.Products;
using FastEndpoints;
using MediatR;

namespace Developer.Assignment.Api.Endpoints.Products;

public class UpdateProductEndpoint(ISender sender) : Ep.Req<UpdateProductRequest>.NoRes
{
    public override void Configure()
    {
        Post("/api/product/update");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateProductRequest request, CancellationToken token)
    {
        var result = await sender.Send(new UpdateProductCommand(request.Id, request.Name, request.Price, request.Description), token);
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
