using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebAPIApplication.Controllers
{
    
    //[Authorize("Admin")]
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        RoleManager<IdentityRole> _roleManager;


        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // GET: api/role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdentityRole>>> Get()
        {
            return await _roleManager.Roles.ToListAsync();
        }
    }
}