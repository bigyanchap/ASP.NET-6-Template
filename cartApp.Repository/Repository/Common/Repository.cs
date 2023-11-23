using System.Linq.Expressions;

namespace cartApp.Repository.Repository.Common
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly CartAppDbContext _context;
        public Repository(CartAppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        #nullable disable
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        #nullable enable

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }

}
