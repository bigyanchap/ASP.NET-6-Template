using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cartApp.Repository.Repository.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private CartAppDbContext _context;

        #nullable disable
        public UnitOfWork(IDbFactory dbFactory, CartAppDbContext dbContext)
        {
            this._dbFactory = dbFactory;
            this._context = dbContext;
        }
        #nullable enable

        public CartAppDbContext DbContext 
        {
            get
            {
                return _context; 
            }
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
