﻿namespace Dev.Data.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> EditAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);

        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllAsNoTracking();
    }
}