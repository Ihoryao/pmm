using System;
using WebAPIApplication.Models;

namespace WebAPIApplication.DAL
{
    public class UnitOfWork : IDisposable
    {
        private SageBookContext _context = new SageBookContext();
        private BookRepository bookRepository;
        private SageRepository sageRepository;

        public BookRepository Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(_context);
                return bookRepository;
            }
        }

        public SageRepository Sages
        {
            get
            {
                if (sageRepository == null)
                    sageRepository = new SageRepository(_context);
                return sageRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}