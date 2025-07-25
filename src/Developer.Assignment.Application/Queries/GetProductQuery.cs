using Developer.Assignment.Domain.Models;
using FluentResults;
using MediatR;

namespace Developer.Assignment.Application.Queries;

public record GetProductQuery(int ProductId) : IRequest<Result<Product>>;
