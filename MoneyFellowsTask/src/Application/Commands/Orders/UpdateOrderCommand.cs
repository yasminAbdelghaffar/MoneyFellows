using Core.DTOs.Order;
using MediatR;

namespace Application.Commands.Orders
{
    public record UpdateOrderCommand(OrderDTO Order, int Id) : IRequest;
}
