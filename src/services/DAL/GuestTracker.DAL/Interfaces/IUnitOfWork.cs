using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestTracker.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        //DbContext Context { get; }
        IGuestRepository Guest { get; }
        IVisitDetailRepository VisitDetail { get; }
        //IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int Complete();
        Task<int> CompleteAsync();
        //int Commit();
    }
    //public  interface IUnitOfWork<TContext>:IUnitOfWork where TContext:DbContext
    //{
    //    TContext Context { get; }
    //}
}
