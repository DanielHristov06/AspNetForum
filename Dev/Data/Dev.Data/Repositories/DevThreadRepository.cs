using Dev.Data.Models;
using Dev.Web.Data;
using Microsoft.AspNetCore.Http;

namespace Dev.Data.Repositories
{
    public class DevThreadRepository : MetadataBaseGenericRepository<DevThread>
    {
        public DevThreadRepository(DevDbContext dbc, IHttpContextAccessor httpContextAccessor)
            : base(dbc, httpContextAccessor)
        {
        }
    }
}