using Dev.Data.Models;
using Dev.Service.Models;

namespace Dev.Service.Thread
{
    public interface IThreadService : IGenericService<DevThread, ThreadServiceModel>
    {
        Task<CommentServiceModel> CreateCommentOnThread(CommentServiceModel commentServiceModel, string threadId, string? parentCommentId = null);

        Task<UserThreadReactionServiceModel> CreateReactionOnThread(string threadId, string reactionId);

        IQueryable<ThreadServiceModel> GetAllByCommunityId(string communityId);
    }
}