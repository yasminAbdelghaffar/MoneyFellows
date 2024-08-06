using Core.DTOs.Product;
using MediatR;

namespace Application.Queries.Product
{
    public record GetAllProductsQuery(int? PageSize, int? PageNumber, string? Merchant) : IRequest<List<ProductDTO>>;
}
