using System.Collections.Generic;
using System.Linq;
using WpfApp3.Models;

namespace WpfApp3.Services
{
    public class BookServices
    {
        readonly ApplicationContext context = new ApplicationContext();
        public Book newBook = new Book();
        public Book selectedBook = new Book();

        public List<Book> GetBooks()
        {
            return context.Books.ToList();
        }

        public void AddBook()
        {
            context.Books.Add(newBook);
            context.SaveChanges();
            newBook = new Book();
        }

        public void UpdateBook()
        {
            context.Books.Update(selectedBook);
            context.SaveChanges();
        }

        public void DeleteBook()
        {
            context.Books.Remove(selectedBook);
            context.SaveChanges();
        }
    }
}