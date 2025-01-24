using Dev.Data.Models;
using Dev.Web.Data;
using Microsoft.AspNetCore.Http;

namespace Dev.Data.Repositories
{
    public class CommentRepository : MetadataBaseGenericRepository<Comment>
    {
        public CommentRepository(DevDbContext dbc, IHttpContextAccessor httpContextAccessor)
            : base(dbc, httpContextAccessor)
        {
        }
    }
}