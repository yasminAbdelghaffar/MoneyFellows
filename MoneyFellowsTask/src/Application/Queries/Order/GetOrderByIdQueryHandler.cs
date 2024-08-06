using Core.DTOs.Order;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Queries.Order
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDTO>
    {
        private readonly IOrderRepository _OrderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }

        public async Task<OrderDTO> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _OrderRepository.GetByIdAsync(request.id);
        }
    }
}
