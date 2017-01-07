using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Weightlifting.Data.Service
{
    public interface IService<T>
    {
        DbContext DbContext();
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        void Add(T Entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
        Task UpdateAsync(T entity);
    }
}
