using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    [Route("api/sage")]
    [ApiController]
    public class SageController : ControllerBase
    {
        private readonly SageBookContext _context;

        public SageController(SageBookContext context)
        {
            _context = context;
        }

        // GET: api/Sage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sage>>> Get()
        {
            return await _context.Sages.ToListAsync();
        }

        // GET: api/Sage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sage>> Get(int id)
        {
            Sage sage = await _context.Sages.FindAsync(id);
            if (sage == null)
            {
                return NotFound();
            }

            return sage;
            // return new ObjectResult(book);
        }

        // GET: api/Sage/5
        // [HttpGet("api/Sage/GetSageBooks/{id}")]
        // public async Task<ActionResult<Sage>> GetSageBooks(int id)
        // {
        //     Sage sage = await _context.Sages.FindAsync(id);
        //     if (sage == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     return sage;
        //     // return new ObjectResult(book);
        // }

        // POST: api/Post
        [HttpPost]
        public async Task<ActionResult<Sage>> Post(Sage sage)
        {
            _context.Sages.Add(sage);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(Get), new {id = sage.SageId}, sage);
        }

        // PUT: api/TodoItems/5
        //[HttpPut("{id}")]
        [HttpPut]
        public async Task<IActionResult> Put(Sage sage)
        {
            if (sage == null)
            {
                return BadRequest();
            }

            if (!_context.Sages.Any(s => s.SageId == sage.SageId))
            {
                return NotFound();
            }

            _context.Sages.Update(sage);
            await _context.SaveChangesAsync();
            //_context.Entry(book).State = EntityState.Modified;

            //return Ok(sage);
            return NoContent();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            Sage sage = await _context.Sages.FindAsync(id);
            if (sage == null)
            {
                return NotFound();
            }

            _context.Sages.Remove(sage);
            await _context.SaveChangesAsync();

            return NoContent();
            //return Ok(book);
        }
    }
}