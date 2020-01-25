using GuestTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestTracker.DAL.Interfaces
{
    public interface IDataContext
    {
        DbSet<Guest> Guests { get; set; }
        DbSet<VisitDetail> VisitDetails { get; set; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
