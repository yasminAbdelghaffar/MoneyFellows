using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Commands.Products
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, long>
    {
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<long> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductName = request.Product.ProductName,
                ProductDescription = request.Product.ProductDescription,
                ProductImage = request.Product.ProductImage,
                Price = request.Product.Price,
                Merchant = request.Product.Merchant
            };

            await _productRepository.AddAsync(product);
            return product.Id;
        }
    }
}
