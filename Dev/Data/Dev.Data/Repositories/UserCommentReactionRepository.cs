using Dev.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Data.Repositories
{
    public class UserCommentReactionRepository : BaseGenericRepository<UserCommentReaction>
    {
        public UserCommentReactionRepository(DevDbContext dbContext) : base(dbContext)
        {
        }
    }
}
