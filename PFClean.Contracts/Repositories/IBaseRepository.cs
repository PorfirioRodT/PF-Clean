using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFClean.Contracts.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T?> GetByGuidAsync(Guid id);
        Task UpdateAsyc(T entity);
        Task<T> AddAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
