using Dev.Data.Models;
using Dev.Data.Repositories;
using Dev.Service.Mappings;
using Dev.Service.Models;
using Dev.Service.User;
using Microsoft.EntityFrameworkCore;

namespace Dev.Service.Thread
{
    public class ThreadService : IThreadService
    {
        private readonly DevThreadRepository devThreadRepository;

        private readonly DevTagRepository devTagRepository;

        private readonly HubRepository hubRepository;

        private readonly CommentRepository commentRepository;

        private readonly ReactionRepository reactionRepository;

        private readonly IUserContextService userContextService;

        public ThreadService(
            DevThreadRepository devThreadRepository,
            DevTagRepository devTagRepository,
            HubRepository hubRepository,
            CommentRepository commentRepository,
            IUserContextService userContextService,
            ReactionRepository reactionRepository)
        {
            this.devThreadRepository = devThreadRepository;
            this.devTagRepository = devTagRepository;
            this.hubRepository = hubRepository;
            this.commentRepository = commentRepository;
            this.userContextService = userContextService;
            this.reactionRepository = reactionRepository;
        }

        public async Task<ThreadServiceModel> CreateAsync(ThreadServiceModel model)
        {
            DevThread devThread = model.ToEntity();

            devThread.Tags = devThread.Tags.Select(async tag => {
                return (await this.devTagRepository.CreateAsync(tag));
            }).Select(t => t.Result).ToList();

            devThread.Hub = await this.hubRepository.GetAll()
                .SingleOrDefaultAsync(community => community.Id == model.Hub.Id);

            await devThreadRepository.CreateAsync(devThread);

            return devThread.ToModel();
        }

        public async Task<CommentServiceModel> CreateCommentOnThread(CommentServiceModel commentServiceModel, string threadId, string? parentCommentId = null)
        {
            Data.Models.Comment entity = commentServiceModel.ToEntity();

            if (parentCommentId != null)
            {
                Data.Models.Comment? parent = await commentRepository.GetAll()
                    .SingleOrDefaultAsync(c => c.Id == parentCommentId);

                if (parent == null)
                {
                    throw new ArgumentException("Parent comment not found for id - " + parentCommentId);
                }

                entity.Parent = parent;
            }

            entity = await this.commentRepository.CreateAsync(entity);

            DevThread commentThread = await this.InternalGetByIdAsync(threadId);

            commentThread.Comments.Add(new UserThreadComment
            {
                Comment = entity,
                Thread = commentThread,
                User = (await this.userContextService.GetCurrentUserAsync())
            });

            await this.devThreadRepository.UpdateAsync(commentThread);

            return entity.ToModel(CommentMappingsContext.Reaction);
        }

        public async Task<UserThreadReactionServiceModel> CreateReactionOnThread(string threadId, string reactionId)
        {
            DevThread reactionThread = await this.InternalGetByIdAsync(threadId);
            Data.Models.Reaction reaction = await reactionRepository.GetAll()
                    .SingleOrDefaultAsync(r => r.Id == reactionId);

            var utr = new UserThreadReaction
            {
                Reaction = reaction,
                Thread = reactionThread,
                User = (await userContextService.GetCurrentUserAsync())
            };

            reactionThread.Reactions.Add(utr);

            await devThreadRepository.UpdateAsync(reactionThread);

            return utr.ToModel(UserThreadReactionMappingsContext.User);
        }

        public Task<ThreadServiceModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ThreadServiceModel> GetAll()
        {
            return InternalGetAll()
                .Select(t => t.ToModel());
        }

        public IQueryable<ThreadServiceModel> GetAllByCommunityId(string communityId)
        {
            return InternalGetAll().Where(t => t.Hub.Id == communityId).Select(t => t.ToModel());
        }

        public async Task<ThreadServiceModel> GetByIdAsync(string id)
        {
            return (await InternalGetAll().SingleOrDefaultAsync(thread => thread.Id == id))?.ToModel();
        }

        public Task<ThreadServiceModel> UpdateAsync(string id, ThreadServiceModel model)
        {
            throw new NotImplementedException();
        }

        private async Task<DevThread> InternalGetByIdAsync(string id)
        {
            return await InternalGetAll().SingleOrDefaultAsync(thread => thread.Id == id);
        }

        private IQueryable<DevThread> InternalGetAll()
        {
            return devThreadRepository.GetAll()
                .Include(t => t.Tags)
                .Include(t => t.Hub)
                    //.ThenInclude(c => c.ThumbnailPhoto)
                .Include(t => t.Reactions)
                    .ThenInclude(utr => utr.Reaction)
                        .ThenInclude(r => r.Emote)
                .Include(t => t.Attachments)
                .Include(t => t.Comments)
                .Include(t => t.CreatedBy)
                .Include(t => t.UpdatedBy)
                .Include(t => t.DeletedBy);
        }

        public Task<DevThread> InternalCreateAsync(DevThread model)
        {
            throw new NotImplementedException();
        }

        Task<DevThread> IGenericService<DevThread, ThreadServiceModel>.InternalGetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}