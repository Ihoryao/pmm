using System.Collections.Generic;

namespace WpfApp3.Models
{
    public class Sage
    {
        public int SageId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Photo { get; set; }
        public string City { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}