using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace cartApp.Repository.Repository.Common
{

    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        /*NOTES: The reason why there isn't an Update method 
         * in new repository patterns (Entity Framework 6) 
         * is because there's no need for one. 
         * You simply fetch your record by id, 
         * make your changes and then commit/save.
        */
    }
}
