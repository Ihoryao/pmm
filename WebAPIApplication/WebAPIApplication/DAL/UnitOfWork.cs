using System;
using WebAPIApplication.Models;

namespace WebAPIApplication.DAL
{
    public class UnitOfWork : IDisposable
    {
        private SageBookContext _context = new SageBookContext();
        private BookRepository _bookRepository;
        private SageRepository _sageRepository;
        
        private AuthContext _authContext = new AuthContext();
        private UserRepository _userRepository;

        public BookRepository Books
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new BookRepository(_context);
                return _bookRepository;
            }
        }

        public SageRepository Sages
        {
            get
            {
                if (_sageRepository == null)
                    _sageRepository = new SageRepository(_context);
                return _sageRepository;
            }
        }

        public UserRepository Users
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_authContext);
                return _userRepository;
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