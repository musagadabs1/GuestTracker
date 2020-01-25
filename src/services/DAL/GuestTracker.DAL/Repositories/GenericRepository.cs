using GuestTracker.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GuestTracker.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        public GenericRepository(DbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                
               // _unitOfWork.Context.Set<T>().Add(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                //await  _unitOfWork.Context.Set<T>().AddAsync(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                T existing = _context.Set<T>().Find(entity);
                if (existing != null) _context.Set<T>().Remove(existing);

                //T existing = _unitOfWork.Context.Set<T>().Find(entity);
                //if (existing != null) _unitOfWork.Context.Set<T>().Remove(existing);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<T> Get()
        {
            try
            {
                return _context.Set<T>().ToList<T>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _context.Set<T>().Where(predicate).ToList<T>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync<T>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _context.Set<T>().Where(predicate).ToListAsync<T>();//.AsAsyncEnumerable();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
