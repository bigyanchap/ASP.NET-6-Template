using cartapp.Controllers;
using cartApp.Entities;
using cartApp.Services.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace cartApp.Test
{
    [TestClass]
    public class ProductsControllerTest
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly ProductsController _controller;

        public ProductsControllerTest()
        {
            _mockProductService = new Mock<IProductService>();
            _controller = new ProductsController(_mockProductService.Object);
        }

        [TestMethod]
        public void GetProducts_ReturnsOkObjectResult_WithAListOfProducts()
        {
            // Arrange
            var fakeProducts = new List<Product>
            {
                new Product { Id = 1, Name = "iphone 15 pro", Description = "iphone 15 pro desc.", Price = 1000 },
                new Product { Id = 2, Name = "mac book pro", Description = "macbook pro desc.", Price = 3000 }
            };
            _mockProductService.Setup(service => service.GetAllProducts()).Returns(fakeProducts);

            // Act
            var result = _controller.GetProducts();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOfType(okResult.Value, typeof(List<Product>));
            var productList = okResult.Value as List<Product>;
            Assert.AreEqual(2, productList.Count); //2 products in your fake list
        }

        [TestMethod]
        public void GetProduct_ReturnsOkWithProduct_WhenProductExists()
        {
            // Arrange
            var productId = 1;
            var fakeProduct = new Product { Id = productId, Name = "hp book 12.", Description = "hp book pro.................", Price = 1000 };
            _mockProductService.Setup(service => service.GetProductById(productId)).Returns(fakeProduct);

            // Act
            var result = _controller.GetProduct(productId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult.Value);
            Assert.AreEqual(fakeProduct, okResult.Value as Product);
        }

        [TestMethod]
        public void GetProduct_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            var productId = 1;
            _mockProductService.Setup(service => service.GetProductById(productId)).Throws(new Exception("Error message"));

            // Act
            var result = _controller.GetProduct(productId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            var badRequestResult = result as BadRequestObjectResult;
            Assert.AreEqual("Error message", badRequestResult.Value);
        }

        [TestMethod]
        public void CreateProduct_ReturnsOkResult_WhenProductIsAdded()
        {
            // Arrange
            var newProduct = new Product { Name = "iphone 12 pro", Description = "iphone 12 pro desc.", Price = 900 };

            // No setup required for AddProduct as it returns void, just verification is needed

            // Act
            var result = _controller.CreateProduct(newProduct);

            // Assert
            _mockProductService.Verify(service => service.AddProduct(newProduct), Times.Once);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

    }
}