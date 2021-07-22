using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_book_repository_webapi.Contracts;
using test_book_repository_webapi.Models;
using test_book_repository_webapi.Repositories;

namespace test_book_repository_webapi.Context
{
    public class UnitOfWork
    {
        private IGenericRepository<Book> _gnrBookRepository;
        public IGenericRepository<Book> GenericRepository {
            get {
                if (_gnrBookRepository == null) {
                    _gnrBookRepository = new GenericRepository<Book>();
                }
                return _gnrBookRepository;
            }
        }
    }
}


