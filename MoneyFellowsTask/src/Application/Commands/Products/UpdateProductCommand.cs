using Core.DTOs.Product;
using MediatR;

namespace Application.Commands.Products
{
    public record UpdateProductCommand(ProductDTO Product, long Id) : IRequest;
}
