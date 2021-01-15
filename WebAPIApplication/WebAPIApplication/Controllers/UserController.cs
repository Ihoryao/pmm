using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIApplication.DAL;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UnitOfWork unitOfWork;
        private UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            unitOfWork = new UnitOfWork();
            _userManager = userManager;
        }

        // GET: api/user
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<User>>> Get()
        // {
        //     return await _userManager.Users.ToListAsync();
        // }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return unitOfWork.Users.GetAll().ToList();
            //return await _context.Sages.ToListAsync();
            //            return await _userManager.Users.ToListAsync();
        }
    }
}