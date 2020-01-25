using GuestTracker.DAL.Interfaces;
using GuestTracker.DAL.Models;
using GuestTracker.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GuestTracker.DAL.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        //public DbContext Context { get; }
        protected GuestDbContext _context;
        public UnitOfWork(GuestDbContext context)
        {
            _context = context;
            Guest = new GuestRepository(_context);
            VisitDetail = new VisitDetailRepository(_context);
        }

        public IGuestRepository Guest { get; private set; }

        public IVisitDetailRepository VisitDetail { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        //int IUnitOfWork.Commit()
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
