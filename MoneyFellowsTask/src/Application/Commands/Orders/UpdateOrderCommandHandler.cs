using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.Orders
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = request.Id,
                DeliveryAddress = request.Order.DeliveryAddress,
                TotalCost = request.Order.TotalCost,
                UserId = request.Order.User,
                DeliveryTime = request.Order.DeliveryTime,
                OrderProducts = request.Order.OrderDetails.Select(x => new OrderProducts { ProductId = x.ProductId, Quantity = x.Quantity }).ToList(),
            };

            await _orderRepository.UpdateAsync(order);
        }
    }
}
