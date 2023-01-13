using KbstAPI.Data;
using KbstAPI.Repository.BaseRepositories;
using Microsoft.EntityFrameworkCore;

namespace KbstAPI.Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected KbstContext context;
        protected DbSet<T> dbSet;

        public BaseRepository(KbstContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();  
        }

        public virtual async Task<bool> Add(T entity)
        {
            var p = await dbSet.AddAsync(entity);
            return true;
        }


        public virtual void Delete(int id)
        {
            T? entity = dbSet.Find(id);
            if(entity != null)
                dbSet.Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await this.dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await this.dbSet.FindAsync(id);
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public Task<int> Save()
        {
            return context.SaveChangesAsync();
        }
    }
}
