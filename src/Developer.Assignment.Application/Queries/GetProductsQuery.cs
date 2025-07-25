using Developer.Assignment.Domain.Models;
using MediatR;

namespace Developer.Assignment.Application.Queries;

public record GetProductsQuery : IRequest<IEnumerable<Product>>;
