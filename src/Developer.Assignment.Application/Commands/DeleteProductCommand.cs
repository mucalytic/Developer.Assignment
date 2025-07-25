using FluentResults;
using MediatR;

namespace Developer.Assignment.Application.Commands;

public record DeleteProductCommand(int ProductId) : IRequest<Result<Unit>>;
