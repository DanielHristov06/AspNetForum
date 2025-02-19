using Dev.Data.Models;
using Dev.Data.Repositories;
using Dev.Service.Community;
using Dev.Service.Mappings;
using Dev.Service.Models;
using Dev.Service.Tag;
using Microsoft.EntityFrameworkCore;

namespace Dev.Service.Thread
{
    public class ThreadService : IThreadService
    {
        private readonly DevThreadRepository threadRepository;
        private readonly IDevTagService devTagService;
        private readonly IHubService hubService;

        public ThreadService(DevThreadRepository threadRepository, IDevTagService devTagService, IHubService hubService)
        {
            this.threadRepository = threadRepository;
            this.devTagService = devTagService;
            this.hubService = hubService;
        }

        public async Task<ThreadServiceModel> CreateAsync(ThreadServiceModel model)
        {
            DevThread thread = model.ToEntity();

            thread.Tags = thread.Tags.Select(async tag => {
                return (await this.devTagService.InternalCreateAsync(tag));
            }).Select(t => t.Result).ToList();

            thread.Hub = await hubService.InternalGetByIdAsync(model.Hub.Id);

            await threadRepository.CreateAsync(thread);

            return thread.ToModel();
        }

        public Task<ThreadServiceModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ThreadServiceModel> GetAll()
        {
            return threadRepository.GetAll()
                .Include(t => t.Hub)
                .Include(t => t.Tags)
                .Include(t => t.CreatedBy)
                .Include(t => t.UpdatedBy)
                .Include(t => t.DeletedBy)
                .Select(t => t.ToModel());
        }

        public Task<ThreadServiceModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<DevThread> InternalCreateAsync(DevThread model)
        {
            throw new NotImplementedException();
        }

        public Task<DevThread> InternalGetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ThreadServiceModel> UpdateAsync(string id, ThreadServiceModel model)
        {
            throw new NotImplementedException();
        }
    }
}