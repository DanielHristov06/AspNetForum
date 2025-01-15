using Dev.Data.Models;
using Dev.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Dev.Data.Repositories
{
    public abstract class BaseGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity {
        protected readonly DevDbContext dbc;

        protected BaseGenericRepository(DevDbContext dbc) {
            this.dbc = dbc;
        }

        public async Task<TEntity> CreateAsync(TEntity entity) {
            await dbc.AddAsync(entity);
            await dbc.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity) {
            dbc.Remove(entity);
            await dbc.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> EditAsync(TEntity entity) {
            dbc.Update(entity);
            await dbc.SaveChangesAsync();
            return entity;
        }

        public IQueryable<TEntity> GetAllAsNoTracking() {
            return dbc.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> GetAll() {
            return dbc.Set<TEntity>().AsQueryable<TEntity>();
        }
    }
}