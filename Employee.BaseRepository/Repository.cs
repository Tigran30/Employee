using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Employee.BaseRepository
{
    public class Repository<T> : IDisposable
        where T : class
    {
        public Repository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        private DbSet<T> DbSet { set; get; }

        private DbContext Context { set; get; }

        public async Task<EntityEntry<T>> AddAsync(T entity) => await DbSet.AddAsync(entity);
        public IQueryable<T> AsQueryable() => DbSet.AsQueryable();
        public void Delete(T entity) => DbSet.Remove(entity);

        public async Task SaveChangesAsync() => await Context.SaveChangesAsync();
        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}