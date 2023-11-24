using AutoMapper;
using cartApp.Entities;
using cartApp.Repository.Repository.Common;
using cartApp.Repository.Repository.Infrastructure;
using cartApp.Services.Implementation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cartApp.Test
{
    [TestClass]
    public class ProductsServiceTest
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ProductService _service;

        public ProductsServiceTest()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _service = new ProductService(_mockProductRepository.Object, _mockUnitOfWork.Object, _mockMapper.Object);
        }

        [TestMethod]
        public async Task DeleteProduct_RemovesProductAndCommits_WhenProductExists()
        {
            // Arrange
            var productId = 1;
            var product = new Product { Id = productId };
            _mockProductRepository.Setup(repo => repo.GetById(productId)).Returns(product);
            _mockProductRepository.Setup(repo => repo.Remove(product));
            _mockUnitOfWork.Setup(uow => uow.Commit());

            // Act
            await _service.DeleteProduct(productId);

            // Assert
            _mockProductRepository.Verify(repo => repo.GetById(productId), Times.Once);
            _mockProductRepository.Verify(repo => repo.Remove(product), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }

        [TestMethod]
        public async Task AddProduct_CallsAddAndCommit_WhenProductIsAdded()
        {
            // Arrange
            var newProduct = new Product { Name = "iphone 12 pro", Description = "iphone 12 pro desc.", Price = 900 };

            // Act
            await _service.AddProduct(newProduct);

            // Assert
            _mockProductRepository.Verify(repo => repo.Add(newProduct), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.Commit(), Times.Once);
        }
        [TestMethod]
        public async Task GetAllProducts()
        {
            //Arrange
            var fakeProducts = new List<Product>
            {
                new Product { Id = 1, Name = "iphone 15 pro", Description = "iphone 15 pro desc.", Price = 1000 },
                new Product { Id = 2, Name = "mac book pro", Description = "macbook pro desc.", Price = 3000 }
            };
            _mockProductRepository.Setup(repo => repo.GetAll()).Returns(fakeProducts);

            //Act
            var products =  _service.GetAllProducts();

            // Assert
            Assert.IsNotNull(products);
            Assert.AreEqual(2, products.Count()); // Assuming 2 products in fake list
            CollectionAssert.AreEqual(fakeProducts, new List<Product>(products));

        }
    }
}
