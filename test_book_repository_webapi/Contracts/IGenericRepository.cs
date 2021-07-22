using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace test_book_repository_webapi.Contracts
{
    public interface IGenericRepository<T> 
    {
        IEnumerable<T> GetAll();
        Task<T> FindById(int id);
        Task<T> Update(T entity);
        Task<T> Delete(int id);

        Task<T> Add(T entity);
        Task<bool> IsExists(int id, Expression<Func<T, bool>> predicate = null);
    }
}
