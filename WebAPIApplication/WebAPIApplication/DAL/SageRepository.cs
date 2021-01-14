using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPIApplication.Models;

namespace WebAPIApplication.DAL
{
    public class SageRepository : IRepository<Sage>
    {
        private SageBookContext _context;

        public SageRepository(SageBookContext context)
        {
            this._context = context;
        }

        public IEnumerable<Sage> GetAll()
        {
            return _context.Sages;
        }

        public Sage Get(int id)
        {
            return _context.Sages.Find(id);
        }

        public void Create(Sage sage)
        {
            _context.Sages.Add(sage);
        }

        public void Update(Sage sage)
        {
            _context.Entry(sage).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Sage sage = _context.Sages.Find(id);
            if (sage != null)
                _context.Sages.Remove(sage);
        }
    }
}