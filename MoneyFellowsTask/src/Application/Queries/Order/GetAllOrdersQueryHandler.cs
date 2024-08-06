using Core.DTOs.Order;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Queries.Order
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDTO>>
    {
        private readonly IOrderRepository _OrderRepository;

        public GetAllOrdersQueryHandler(IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }

        public async Task<List<OrderDTO>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _OrderRepository.GetAllAsync(request.UserId, request.PageNumber, request.PageSize);
        }
    }
}
