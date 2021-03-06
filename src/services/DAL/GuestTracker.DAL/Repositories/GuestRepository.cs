﻿using GuestTracker.DAL.Interfaces;
using GuestTracker.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestTracker.DAL.Repositories
{
    public class GuestRepository:GenericRepository<Guest>,IGuestRepository
    {
        private GuestDbContext _dbContext;
        public GuestRepository(GuestDbContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guest> GetGuestByName(string name)
        {
            return await _dbContext.Guests.FirstOrDefaultAsync(x => x.GuestName.Equals(name));
        }

        public async Task<Guest> GetGuestByVisitDetailIdAsync(Guid id)
        {
            return await _dbContext.Guests.FirstOrDefaultAsync(x => x.VisitDetailId==id);
        }

        public async Task<IEnumerable<Guest>> GetGuests(string name)
        {
            return await _dbContext.Guests.Where(x => x.GuestName.Equals(name)).ToListAsync();
        }

        public void UpdateGuest(Guest guest)
        {
            _dbContext.Guests.Update(guest);
        }
    }
}
