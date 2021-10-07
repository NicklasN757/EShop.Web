using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Adds a new entity to the database
        /// </summary>
        Task CreateAsync(T entity);

        /// <summary>
        /// Updates a entity from the database
        /// </summary>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Gets all entities from a database table
        /// </summary>
        /// <returns>A list of entities</returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Get a entity by its id
        /// </summary>
        /// <returns>A entity</returns>
        Task<T> GetByIdAsync(object id);
    }
}