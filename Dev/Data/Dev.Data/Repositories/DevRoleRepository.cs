using Dev.Data.Models;
using Dev.Web.Data;

namespace Dev.Data.Repositories
{
    public class DevRoleRepository : BaseGenericRepository<DevRole>
    {
        public DevRoleRepository(DevDbContext dbc) : base(dbc)
        {
        }
    }
}
