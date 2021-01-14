using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPIApplication.Models;

namespace WebAPIApplication.DAL
{
    public class SageBookRepository : IRepository<Book>
    {
        private SageBookContext db;
 
        public SageBookRepository(SageBookContext context)
        {
            this.db = context;
        }
 
        public IEnumerable<Book> GetAll()
        {
            return db.Books;
        }
 
        public Book Get(int id)
        {
            return db.Books.Find(id);
        }
 
        public void Create(Book book)
        {
            db.Books.Add(book);
        }
 
        public void Update(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }
 
        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }
    }
}