using Core.DTOs.Product;
using MediatR;

namespace Application.Queries
{
    public record GetProductByIdQuery(long id) : IRequest<ProductDTO>;
}
