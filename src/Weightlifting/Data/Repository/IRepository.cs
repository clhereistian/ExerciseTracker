using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Weightlifting.Data.Repository
{
    public interface IRepository<T>
    {
        DbContext DbContext();
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        void Add(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
        Task UpdateAsync(T entity);
    }
}
