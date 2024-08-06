using Core.DTOs.Order;
using MediatR;

namespace Application.Queries.Order
{
    public record GetOrderByIdQuery(long id) : IRequest<OrderDTO>;
}
