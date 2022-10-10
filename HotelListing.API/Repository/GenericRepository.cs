using HotelListing.API.Contracts;
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace HotelListing.API.Repository
{
    public class GenericRepository <T> : IGenericRepository <T> where T : class
    {
        private readonly HotelListingDbContext _context;

        public GenericRepository(HotelListingDbContext context)
        {
            this._context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            //Find the entity, remove and only save changes async
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            //Return a boolean (false) = it's null and means that the record doesn't exists
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            //Give me the list 
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            //Give me only one record with the Id
            if (id == null)
            {
                return null;
            }
            return await _context.Set<T>().FindAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
