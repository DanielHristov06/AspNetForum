using Dev.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Data.Repositories
{
    public class UserThreadReactionRepository : BaseGenericRepository<UserThreadReaction>
    {
        public UserThreadReactionRepository(DevDbContext dbContext) : base(dbContext)
        {
        }
    }
}
