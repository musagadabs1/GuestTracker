using GuestTracker.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuestTracker.DAL.Interfaces
{
    public interface IVisitDetailRepository:IGenericRepository<VisitDetail>
    {
        //VisitDetail GuestDetailByGuestId(Guid id);
        Task<IEnumerable<VisitDetail>> GetVisitDetailsByStatusAsync(GuestVisitStatus status);
        Task<IEnumerable<VisitDetail>> GetVisitDetailsByVisitDateAsync();
        Task<IEnumerable<VisitDetail>> GetVisitDetailsByVisitDateAndStatusAsync();
        Task<VisitDetail> GetVisitDetailByGuestNameAsync(string name);
        //Task<bool> IsVisitorIn(string name,GuestVisitStatus status,DateTime visitDate);
        bool IsVisitorIn(string name,DateTime visitDate);
        void UpdateVisitDetail(VisitDetail visitDetail);

        //Task<IList<VisitDetail>> GetAllVisitDetailAsync();
        Task<VisitDetail> GetVisitDetailAsync(Guid id);
        //Task<IList<VisitDetail>> GetVisitDetailAsync(Expression<Func<VisitDetail, bool>> expression);
        //Task AddVisitDetailAsync(VisitDetail guest);
        //Task UpdateVisitDetails(Guid id);
        //Task DeleteVisitDetail(VisitDetail guest);
        //Task SaveVisitDetailAsync();
    }
}
