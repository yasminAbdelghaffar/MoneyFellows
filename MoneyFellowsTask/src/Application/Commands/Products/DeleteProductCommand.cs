using MediatR;

namespace Application.Commands.Products
{
    public record DeleteProductCommand(long id) : IRequest;
}
