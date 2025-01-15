using Dev.Data.Models;
using Dev.Web.Data;

namespace Dev.Data.Repositories
{
    internal class AttachmentRepository : BaseGenericRepository<Attachment>
    {
        public AttachmentRepository(DevDbContext dbc) : base(dbc)
        {
        }
    }
}