using Core.DTOs.Order;
using MediatR;

namespace Application.Commands.Orders
{
    public record AddOrderCommand(OrderDTO Order) : IRequest<long>;
}
