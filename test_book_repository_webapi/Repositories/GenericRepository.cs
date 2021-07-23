using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using test_book_repository_webapi.Context;
using test_book_repository_webapi.Contracts;
using test_book_repository_webapi.Models;

namespace test_book_repository_webapi.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly BookStoreTestContext _db;
        private readonly DbSet<T> _dbSet;
        private readonly UnitOfWork _uow;
        public GenericRepository(UnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _dbSet = _db.Set<T>();
        }
        public virtual async Task<T> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Delete(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> FindById(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public virtual async Task<bool> IsExists(int id, Expression<Func<T, bool>> predicate = null)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public virtual async Task<T> Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
