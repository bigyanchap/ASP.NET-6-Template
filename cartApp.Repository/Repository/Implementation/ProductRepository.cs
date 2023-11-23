using cartApp.Entities;
using cartApp.Repository.Repository.Common;
using cartApp.Repository.Repository.Infrastructure;

namespace cartApp.Repository.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CartAppDbContext context) : base(context)
        {

        }
    }
}
