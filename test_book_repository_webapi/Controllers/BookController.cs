using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_book_repository_webapi.Contracts;
using test_book_repository_webapi.Models;

namespace test_book_repository_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IGenericRepository<Book> _db;
        public BookController(IGenericRepository<Book> db) {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks() {
            return new ObjectResult(_db.GetAll().ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooks(int id) {
            return Ok(id.ToString());
        }


        [HttpPost]
        public async Task<IActionResult> PostBook(Book book) {
            await _db.Add(book);
            return Ok();
        }

    }
}
