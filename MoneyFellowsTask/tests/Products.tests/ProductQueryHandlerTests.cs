using Application.Queries.Product;
using Core.DTOs.Product;
using Core.Interfaces.Repositories;
using Moq;
using Xunit;

namespace Products.Tests.Application.Features.Queries
{
    public class ProductQueryHandlerTests
    {
        [Fact]
        public async Task Should_Return_ProductDTO_Query()
        {
            // Arrange
            var query = new GetProductByIdQuery(1);
            var productDTO = new ProductDTO { Id = 1, ProductName = "Test Product" };

            var productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(repo => repo.GetByIdAsync(query.id)).ReturnsAsync(productDTO);

            var handler = new GetProductByIdQueryHandler(productRepositoryMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(productDTO, result);
        }
    }
}