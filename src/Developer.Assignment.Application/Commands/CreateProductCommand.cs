using Developer.Assignment.Domain.Models;
using FluentResults;
using MediatR;

namespace Developer.Assignment.Application.Commands;

public record CreateProductCommand(string Name, decimal Price, string Description) : IRequest<Result<Product>>;
