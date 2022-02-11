using System.Collections.Generic;
using System.Threading.Tasks;

namespace Applications.Interfaces
{
   public interface IGenericRepository<T> where T: class
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
    }
}
