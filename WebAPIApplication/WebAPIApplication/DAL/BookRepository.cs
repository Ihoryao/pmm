using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPIApplication.Models;

namespace WebAPIApplication.DAL
{
    public class BookRepository : IRepository<Book>
    {
        private SageBookContext _context;

        public BookRepository(SageBookContext context)
        {
            this._context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        public Book Get(int id)
        {
            return _context.Books.Find(id);
        }

        public void Create(Book book)
        {
            _context.Books.Add(book);
        }

        public void Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Book book = _context.Books.Find(id);
            if (book != null)
                _context.Books.Remove(book);
        }
    }
}