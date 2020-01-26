using GuestTracker.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuestTracker.DAL.Interfaces
{
    public interface IGuestRepository:IGenericRepository<Guest>
    {
        Task<Guest> GetGuestByName(string name);
        Task<IEnumerable<Guest>> GetGuests(string name);
        Task<Guest> GetGuestByVisitDetailIdAsync(Guid id);
        void UpdateGuest(Guest guest);

    }
}
