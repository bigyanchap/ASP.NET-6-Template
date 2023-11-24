using cartApp.DTO;
using cartApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cartApp.Services.Infrastructure
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Task AddProduct(Product product);
        Task UpdateProduct(ProductDTO product);
        Task DeleteProduct(int id);
    }
}
