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
        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public Task Add(Product product)
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

        public Task Delete(int id)
        {
            var product = _productRepository.GetById(id);
            _productRepository.Remove(product);
            _unitOfWork.Commit();
            return Task.CompletedTask;
        }

        public IEnumerable<Product> GetAll()
        {
            var products =  this._productRepository.GetAll();
            return products;
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}