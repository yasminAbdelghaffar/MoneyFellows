using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.Products
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = request.Id,
                ProductName = request.Product.ProductName,
                ProductDescription = request.Product.ProductDescription,
                ProductImage = request.Product.ProductImage,
                Price = request.Product.Price,
                Merchant = request.Product.Merchant
            };

            await _productRepository.UpdateAsync(product);
            return product.Id;
        }
    }
}
