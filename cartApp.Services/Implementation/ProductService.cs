using AutoMapper;
using cartApp.DTO;
using cartApp.Entities;
using cartApp.Repository.Repository.Common;
using cartApp.Repository.Repository.Infrastructure;
using cartApp.Services.Infrastructure;

namespace cartApp.Services.Implementation
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public ProductService(
            IProductRepository productRepository, 
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task AddProduct(Product product)
        {
            try
            {
                _productRepository.Add(product);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Task.CompletedTask;
        }

        public Task DeleteProduct(int id)
        {
            var product = _productRepository.GetById(id);
            _productRepository.Remove(product);
            _unitOfWork.Commit();
            return Task.CompletedTask;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products =  this._productRepository.GetAll();
            return products;
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Task UpdateProduct(ProductDTO productDTO)
        {
            var product = this._productRepository.GetById(productDTO.Id);
            _mapper.Map(productDTO, product);
            this._unitOfWork.Commit();
            return Task.CompletedTask;
        }
    }
}