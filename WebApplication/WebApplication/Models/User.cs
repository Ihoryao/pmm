using Microsoft.AspNetCore.Identity;

namespace WebApplication.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}