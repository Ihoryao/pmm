using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using Microsoft.EntityFrameworkCore;
using WpfApp3.Models;

namespace WpfApp3.Services
{
    public class SageServices
    {
        readonly ApplicationContext context = new ApplicationContext();
        public Sage newSage = new Sage();
        public Sage selectedSage = new Sage();

        public List<Sage> GetSages()
        {
            return context.Sages.ToList();
        }

        public void AddSage()
        {
            context.Sages.Add(newSage);
            context.SaveChanges();
            newSage = new Sage();
        }

        public void UpdateSage()
        {
            context.Sages.Update(selectedSage);
            context.SaveChanges();
        }

        public void DeleteSage()
        {
            context.Sages.Remove(selectedSage);
            context.SaveChanges();
        }

        public List<Book> SelectSageBooks()
        {
            int sageId = selectedSage.SageId;

            var query = from book in context.Books
                where book.Sages.Any(s => s.SageId == sageId)
                select book;

            return query.ToList();
        }

        public void DeleteSageBook(Book book)
        {
            //context.Sages.Find(selectedSage.Books.Remove(book));
            //context.Sages.Find(selectedSage.SageId).Books.Remove(book);
            var sageCollections = context.Sages.Include(sage => sage.Books).ToList();
            sageCollections.Find(sage => sage.SageId == selectedSage.SageId).Books.Remove(book);
            context.SaveChanges();
        }

        public void AddSageBook(Book book)
        {
            context.Sages.Find(selectedSage.SageId).Books = new List<Book>();
            context.Sages.Find(selectedSage.SageId).Books.Add(book);
            context.SaveChanges();
        }
    }
}