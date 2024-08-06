using MediatR;

namespace Application.Commands.Orders
{
    public record DeleteOrderCommand(long id) : IRequest;
}
