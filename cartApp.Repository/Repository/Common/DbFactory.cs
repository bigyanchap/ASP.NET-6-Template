using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cartApp.Repository.Repository.Common
{
    public class DbFactory : Disposable, IDbFactory
    {
        CartAppDbContext _dbContext;
        public DbFactory(CartAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public CartAppDbContext Init() 
        { 
            return _dbContext; 
        }

        protected override void DisposeCore()
        {
            if(_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }

    }
}
