using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dev.Web.Data
{
    public class DevDbContext : IdentityDbContext
    {
        public DevDbContext(DbContextOptions<DevDbContext> options)
            : base(options)
        {
        }
    }
}