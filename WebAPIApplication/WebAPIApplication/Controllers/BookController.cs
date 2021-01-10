using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly SageBookContext _context;

        public BookController(SageBookContext context)
        {
            _context = context;
        }

        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return book;
            // return new ObjectResult(book);
        }


        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(Get), new {id = book.BookId}, book);
        }


        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Book>> Put(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            // if (!_context.Books.Find(b))
            // {
            //     return NotFound();
            // }

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }

        // // PUT: api/TodoItems/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> Put(long id, Book book)
        // {
        //     if (id != book.BookId)
        //     {
        //         return BadRequest();
        //     }
        //
        //     _context.Entry(book).State = EntityState.Modified;
        //     await _context.SaveChangesAsync();
        //     return NoContent();
        // }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            Book book = _context.Books.FirstOrDefault(x => x.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }
    }
}