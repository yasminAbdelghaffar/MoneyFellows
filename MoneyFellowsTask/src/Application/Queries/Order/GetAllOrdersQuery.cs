using Core.DTOs.Order;
using MediatR;

namespace Application.Queries.Order
{
    public record GetAllOrdersQuery(int? PageSize, int? PageNumber, int? UserId) : IRequest<List<OrderDTO>>;
}
