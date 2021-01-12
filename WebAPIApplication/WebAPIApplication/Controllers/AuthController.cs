using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAPIApplication.Models;

namespace WebAPIApplication.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        
        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        // [HttpPost]
        // public async Task<IActionResult> Post(User u)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         User user = new User {Email = u.Email, UserName = u.Email};
        //         // додаємо користувача
        //         var result = await _userManager.CreateAsync(user, u.Password);
        //         if (result.Succeeded)
        //         {
        //             // установка кукі
        //             await _signInManager.SignInAsync(user, false);
        //             return RedirectToAction("Index", "Home");
        //         }
        //         else
        //         {
        //             foreach (var error in result.Errors)
        //             {
        //                 ModelState.AddModelError(string.Empty, error.Description);
        //             }
        //         }
        //     }
        //
        //     return View(model);
        // }
    }
}