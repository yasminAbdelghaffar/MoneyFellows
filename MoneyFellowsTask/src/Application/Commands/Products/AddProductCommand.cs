using Core.DTOs.Product;
using MediatR;

namespace Application.Commands.Products
{
    public record AddProductCommand(ProductDTO Product) : IRequest<long>;
}
