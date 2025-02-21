using Dev.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Service.Comment
{
    public interface ICommentService : IGenericService<Data.Models.Comment, CommentServiceModel>
    {
        IQueryable<CommentServiceModel> GetAllByParentId(string parentId);

        Task<IQueryable<CommentServiceModel>> GetAllByThreadId(string threadId);

        Task<UserCommentReactionServiceModel> CreateReactionOnComment(string commentId, string reactionId);
    }
}
