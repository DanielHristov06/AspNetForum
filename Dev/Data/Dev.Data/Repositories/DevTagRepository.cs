using Dev.Data.Models;
using Microsoft.AspNetCore.Http;

namespace Dev.Data.Repositories
{
    public class DevTagRepository : MetadataBaseGenericRepository<DevTag>
    {
        public DevTagRepository(DevDbContext dbc, IHttpContextAccessor httpContextAccessor) : base(dbc, httpContextAccessor)
        {
        }
    }
}