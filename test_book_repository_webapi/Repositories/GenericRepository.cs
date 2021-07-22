using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_book_repository_webapi.Contracts;

namespace test_book_repository_webapi.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> 
    {
        public Task<T> Add(T entity) {
            throw new NotImplementedException();
        }

        public Task<T> Delete(int id) {
            throw new NotImplementedException();
        }

        public Task<T> FindById(int id) {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll() {
            throw new NotImplementedException();
        }

        public Task<T> IsExists(int id) {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity) {
            throw new NotImplementedException();
        }
    }
}
