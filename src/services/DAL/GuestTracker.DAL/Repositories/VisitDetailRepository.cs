using GuestTracker.DAL.Interfaces;
using GuestTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestTracker.DAL.Repositories
{
    public class VisitDetailRepository : GenericRepository<VisitDetail>,IVisitDetailRepository
    {
        private GuestDbContext _dbContext;
        public VisitDetailRepository(GuestDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<VisitDetail> GetVisitDetailByGuestNameAsync(string name)
        {
            return await _dbContext.VisitDetails.FirstOrDefaultAsync(x => x.GuestName.Equals(name)) ;
        }

        public async Task<IEnumerable<VisitDetail>> GetVisitDetailsByStatusAsync(GuestVisitStatus status)
        {
            return await _dbContext.VisitDetails.Where(x => x.Status==status).ToListAsync();
        }

        public async Task<IEnumerable<VisitDetail>> GetVisitDetailsByVisitDateAndStatusAsync()
        {
            return await _dbContext.VisitDetails.Where(x => x.VisitDate == DateTime.Today && x.Status==GuestVisitStatus.IN).ToListAsync();
        }

        public async Task<IEnumerable<VisitDetail>> GetVisitDetailsByVisitDateAsync()
        {
            return await _dbContext.VisitDetails.Where(x => x.VisitDate == DateTime.Today).ToListAsync();
        }

        public void UpdateVisitDetail(VisitDetail visitDetail)
        {
             _dbContext.VisitDetails.Update(visitDetail);
        }
    }
}
