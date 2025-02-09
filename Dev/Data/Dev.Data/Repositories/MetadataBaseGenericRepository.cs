using Dev.Data.Models;
using Dev.Web.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Dev.Data.Repositories
{
    public abstract class MetadataBaseGenericRepository<TEntity> : BaseGenericRepository<TEntity> where TEntity : MetadataBaseEntity
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected MetadataBaseGenericRepository(DevDbContext dbc, IHttpContextAccessor httpContextAccessor) : base(dbc)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public override async Task<TEntity> CreateAsync(TEntity entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.CreatedBy = await this.GetUser();
            return await base.CreateAsync(entity);
        }

        public override async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedOn = DateTime.UtcNow;
            entity.UpdatedBy = await this.GetUser();
            return await base.UpdateAsync(entity);
        }

        public override async Task<TEntity> DeleteAsync(TEntity entity)
        {
            entity.DeletedOn = DateTime.UtcNow; 
            entity.DeletedBy = await this.GetUser();
            return await base.DeleteAsync(entity);
        }

        public async Task<DevUser> GetUser()
        {
            string? userId = this._httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return await this.dbc.Users.SingleOrDefaultAsync(user => user.Id == userId);
        }
    }
}
