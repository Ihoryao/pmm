using System.Collections.Generic;

namespace WebApplication.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Sage> Sages { get; set; }
    }
}