using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFClean.Contracts.Services
{
    public interface IBaseService<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetByGuid(Guid id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
