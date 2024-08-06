using Core.DTOs.Product;
using MediatR;

namespace Application.Queries.Product
{
    public record GetProductByIdQuery(long id) : IRequest<ProductDTO>;
}
