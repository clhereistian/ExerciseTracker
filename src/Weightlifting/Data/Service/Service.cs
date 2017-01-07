using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Weightlifting.Data.Repository;

namespace Weightlifting.Data.Service
{
    public class Service<T> : IService<T> where T : class
    {
        protected IRepository<T> Repo;

        public Service(IRepository<T> repo)
        {
            Repo = repo;
        }

        public DbContext DbContext()
        {
            return Repo.DbContext();
        }

        public virtual void Add(T entity)
        {
            Repo.Add(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return Repo.GetAll();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await Repo.GetByIdAsync(id);
        }

        public virtual async Task RemoveAsync(T entity)
        {
            await Repo.RemoveAsync(entity);
        }

        public virtual async Task SaveAsync()
        {
            await Repo.SaveAsync(); 
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await Repo.UpdateAsync(entity);
        }
    }
}
