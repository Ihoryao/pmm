using System.Collections.Generic;
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

        // Get: 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sage>>> Get()
        {
            return await _context.Sages.ToListAsync();
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult<Book>> Post(Sage sage)
        {
            _context.Sages.Add(sage);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(Get), new {id = sage.SageId}, sage);
        }
    }
}