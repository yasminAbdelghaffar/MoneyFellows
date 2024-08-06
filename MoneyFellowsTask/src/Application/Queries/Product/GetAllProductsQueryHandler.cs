using Core.DTOs.Product;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.Queries.Product
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllAsync(request.Merchant, request.PageNumber, request.PageSize);
        }
    }
}
