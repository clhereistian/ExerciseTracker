using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Weightlifting.Models;

namespace Weightlifting.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext Context;
        protected DbSet<T> DbSet;        

        public Repository(WeightliftingContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public DbContext DbContext()
        {
            return Context;
        }

        public void Add(T entity)
        {
            // Traverses the object graph and sets the state of objects to added
            Context.ChangeTracker.TrackGraph(entity, e => e.Entry.State = EntityState.Added);
            //await Context.Set<T>().AddAsync(entity);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;            
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Context.Update(entity);
            await SaveAsync();
        }
    }
}
