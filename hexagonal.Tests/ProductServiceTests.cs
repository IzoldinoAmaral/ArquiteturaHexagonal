using hexagonal.Application;
using hexagonal.Domain;
using Moq;

namespace hexagonal.Tests;

public class ProductServiceTests
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly Product _testProduct;

    public ProductServiceTests()
    {
        // Arrange
        _productServiceMock = new Mock<IProductService>();
        _testProduct = new Product
        {
            Id = new Guid("f60c1dd2-c88d-4345-b9b5-487c727a53c9"),
            Name = "Product 1",
            Price = 100
        };
    }

    [Fact]
    public async Task AddProductAsync_AddsProductSuccessfully()
    {
        // Arrange
        _productServiceMock.Setup(p => p.AddProductAsync(_testProduct)).ReturnsAsync(_testProduct);

        // Act
        var result = await _productServiceMock.Object.AddProductAsync(_testProduct);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(_testProduct, result);
        _productServiceMock.Verify(p => p.AddProductAsync(_testProduct), Times.Once);
    }
}