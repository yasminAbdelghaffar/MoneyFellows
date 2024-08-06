using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.Orders
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, long>
    {
        private readonly IOrderRepository _orderRepository;

        public AddOrderCommandHandler(IOrderRepository productRepository)
        {
            _orderRepository = productRepository;
        }

        public async Task<long> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                DeliveryAddress = request.Order.DeliveryAddress,
                TotalCost = request.Order.TotalCost,  
                UserId = request.Order.User,
                DeliveryTime = request.Order.DeliveryTime,
            };

            await _orderRepository.AddAsync(order);
            return order.Id;
        }
    }
}
