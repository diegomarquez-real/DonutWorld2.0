using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutWorld.Data.Abstractions.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> FindByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<Guid> CreateAsync(T entity);
        Task<Guid> DeleteAsync(Guid id);
        Task<Guid> UpdateAsync(T entity);
    }
}
