using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_book_repository_webapi.Context;
using test_book_repository_webapi.Contracts;
using test_book_repository_webapi.Models;

namespace test_book_repository_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IUnitOfWork _db;
        public BookController(IUnitOfWork db) {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks() {
            return new ObjectResult(_db.GnrBookRepository.GetAll().ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBooks(int id) {
            return Ok(id.ToString());
        }


        [HttpPost]
        public async Task<IActionResult> PostBook(Book book) {
            await _db.GnrBookRepository.Add(book);
            return Ok();
        }

    }
}
