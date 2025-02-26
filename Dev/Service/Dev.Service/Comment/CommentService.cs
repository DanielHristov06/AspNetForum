using Dev.Data.Models;
using Dev.Data.Repositories;
using Dev.Service.Mappings;
using Dev.Service.Models;
using Dev.Service.User;
using Microsoft.EntityFrameworkCore;

namespace Dev.Service.Comment
{
    public class CommentService : ICommentService
    {
        private readonly CommentRepository commentRepository;
        private readonly DevThreadRepository threadRepository;
        private readonly ReactionRepository reactionRepository;
        private readonly IUserContextService userContextService;

        public CommentService(
            CommentRepository commentRepository,
            DevThreadRepository threadRepository,
            ReactionRepository reactionRepository,
            IUserContextService userContextService)
        {
            this.commentRepository = commentRepository;
            this.threadRepository = threadRepository;
            this.reactionRepository = reactionRepository;
            this.userContextService = userContextService;
        }

        public async Task<CommentServiceModel> CreateAsync(CommentServiceModel model)
        {
            Data.Models.Comment entity = model.ToEntity();

            return (await commentRepository.CreateAsync(entity)).ToModel(CommentMappingsContext.Reaction);
        }

        public Task<CommentServiceModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CommentServiceModel> GetAll()
        {
            return InternalGetAll().Select(c => c.ToModel(CommentMappingsContext.User));
        }

        public IQueryable<CommentServiceModel> GetAllByParentId(string parentId)
        {
            return InternalGetAll()
                .Where(c => c.Parent.Id == parentId)
                .Select(c => c.ToModel(CommentMappingsContext.Parent));
        }

        public Task<CommentServiceModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<CommentServiceModel>> GetAllByThreadId(string threadId)
        {
            DevThread thread = await threadRepository.GetAll()
                .Include(t => t.Comments)
                    .ThenInclude(c => c.Comment)
                        .ThenInclude(c => c.Parent)
                .Include(t => t.Comments)
                    .ThenInclude(c => c.Comment)
                        .ThenInclude(c => c.Replies)
                .Include(t => t.Comments)
                    .ThenInclude(c => c.Comment)
                        .ThenInclude(c => c.Reactions)
                            .ThenInclude(ucr => ucr.Reaction)
                                .ThenInclude(r => r.Emote)
                .SingleOrDefaultAsync(t => t.Id == threadId);

            if (thread == null)
            {
                throw new ArgumentException("No thread exists with id - " + threadId);
            }

            return thread.Comments
                .Where(c => c.Comment.Parent == null)
                .Select(c => c.Comment.ToModel(CommentMappingsContext.Parent))
                .AsQueryable();
        }

        public Task<CommentServiceModel> UpdateAsync(string id, CommentServiceModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<UserCommentReactionServiceModel> CreateReactionOnComment(string commentId, string reactionId)
        {
            Data.Models.Comment reactionComment = await InternalGetByIdAsync(commentId);
            Data.Models.Reaction reaction = await reactionRepository.GetAll()
                    .SingleOrDefaultAsync(r => r.Id == reactionId);

            var ucr = new UserCommentReaction
            {
                Reaction = reaction,
                Comment = reactionComment,
                User = (await userContextService.GetCurrentUserAsync())
            };

            reactionComment.Reactions.Add(ucr);

            await commentRepository.UpdateAsync(reactionComment);

            return ucr.ToModel(UserCommentReactionMappingsContext.User);
        }

        public async Task<Data.Models.Comment> InternalGetByIdAsync(string id)
        {
            return await InternalGetAll().SingleOrDefaultAsync(c => c.Id == id);
        }

        private IQueryable<Data.Models.Comment> InternalGetAll()
        {
            return commentRepository.GetAll()
                .Include(c => c.Attachments)
                .Include(t => t.Reactions)
                .Include(c => c.Replies)
                .Include(t => t.CreatedBy)
                .Include(t => t.UpdatedBy)
                .Include(t => t.DeletedBy);
        }


        public Task<Data.Models.Comment> InternalCreateAsync(Data.Models.Comment model)
        {
            throw new NotImplementedException();
        }
    }
}