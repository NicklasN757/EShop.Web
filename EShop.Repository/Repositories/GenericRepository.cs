using EShop.Repository.Domain;
using EShop.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Repository.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EShopContext _dbContext;
        public GenericRepository(EShopContext eShopContext) => _dbContext = eShopContext;

        //Creates a new entity in the database
        public async Task CreateAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        //Gets all entities from a database table
        public async Task<List<T>> GetAllAsync() => await _dbContext.Set<T>().AsNoTracking().ToListAsync();

        //Gets a single entity from the database table
        public async Task<T> GetByIdAsync(object id) => await _dbContext.Set<T>().FindAsync(id);

        //Updates a entity from the database
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}