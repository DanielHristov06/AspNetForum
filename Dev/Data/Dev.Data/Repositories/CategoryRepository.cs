using Dev.Data.Models;
    using Dev.Web.Data;
    using Microsoft.AspNetCore.Http;


namespace Dev.Data.Repositories
{
    

    public class CategoryRepository : MetadataBaseGenericRepository<Category>
    {
        public CategoryRepository(DevDbContext dbc, IHttpContextAccessor httpContextAccessor)
            : base(dbc, httpContextAccessor)
        {
        }
    }
}