using Developer.Assignment.Application.Commands;
using Developer.Assignment.Contracts.Products;
using Developer.Assignment.Api.Extensions;
using FastEndpoints;
using MediatR;

namespace Developer.Assignment.Api.Endpoints.Products;

public class CreateProductEndpoint(ISender sender) : Ep.Req<CreateProductRequest>.Res<ProductResponse>
{
    public override void Configure()
    {
        Post("/api/product/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateProductRequest request, CancellationToken token)
    {
        var result = await sender.Send(new CreateProductCommand(request.Name, request.Price, request.Description), token);
        if (result.IsSuccess)
        {
            await Send.CreatedAtAsync(
                "/api/product/{productId}",
                new { productId = result.Value.Id },
                new ProductResponse(result.Value.ToDto()), false, token);
        }
        else
        {
            await Send.ErrorsAsync(400, token);
        }
    }
}
