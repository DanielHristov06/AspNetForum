using Dev.Data.Models;
using Dev.Web.Data;
using Microsoft.AspNetCore.Http;

namespace Dev.Data.Repositories
{
    public class ReactionRepository : MetadataBaseGenericRepository<Reaction>
    {
        public ReactionRepository(DevDbContext dbc, IHttpContextAccessor httpContextAccessor)
            : base(dbc, httpContextAccessor)
        {
        }
    }
}