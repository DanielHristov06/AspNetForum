using Dev.Data.Models;
    using Dev.Web.Data;
    using Microsoft.AspNetCore.Http;


namespace Dev.Data.Repositories
{
    

    public class HubRepository : MetadataBaseGenericRepository<Hub>
    {
        public HubRepository(DevDbContext dbc, IHttpContextAccessor httpContextAccessor)
            : base(dbc, httpContextAccessor)
        {
        }
    }
}