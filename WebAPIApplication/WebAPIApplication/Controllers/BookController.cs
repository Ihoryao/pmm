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

        // PUT: api/TodoItems
        //[HttpPut("{id}")]
        [HttpPut]
        public async Task<IActionResult> Put(Book book)
        {

            if (book == null)
            {
                return BadRequest();
            }

            if (!_context.Books.Any(b => b.BookId == book.BookId))
            {
                return NotFound();
            }

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            //_context.Entry(book).State = EntityState.Modified;

            //return Ok(book);
            return NoContent();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
            //return Ok(book);
        }
    }
}