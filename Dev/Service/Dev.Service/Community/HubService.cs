using Dev.Data.Models;
using Dev.Service.Models;
using Microsoft.EntityFrameworkCore;
using Dev.Data.Repositories;
using Dev.Service.Mappings;

namespace Dev.Service.Community
{
    public class HubService : IHubService
    {
        private readonly HubRepository hubRepository;

        private readonly DevTagRepository devTagRepository;

        public HubService(HubRepository hubRepository, DevTagRepository devTagRepository)
        {
            this.hubRepository = hubRepository;
            this.devTagRepository = devTagRepository;
        }

        public async Task<HubServiceModel> CreateAsync(HubServiceModel model)
        {
            Hub hub = model.ToEntity();

            hub.Tags = hub.Tags.Select(async tag => {
                return (await this.devTagRepository.CreateAsync(tag));
            }).Select(t => t.Result).ToList();

            await hubRepository.CreateAsync(hub);

            return hub.ToModel();
        }

        public async Task<HubServiceModel> DeleteAsync(string id)
        {
            Hub hub = await hubRepository.GetAll().SingleOrDefaultAsync(c => c.Id == id);

            if (hub == null)
            {
                throw new NullReferenceException($"No category found with id - {id}.");
            }

            await hubRepository.DeleteAsync(hub);

            return hub.ToModel();
        }

        public IQueryable<HubServiceModel> GetAll()
        {
            return hubRepository.GetAll()
                .Include(c => c.Tags)
                .Include(c => c.CreatedBy)
                .Include(c => c.UpdatedBy)
                .Include(c => c.DeletedBy)
                .Include(c => c.HubPhoto)
                .Include(c => c.BannerPhoto)
                .Select(c => c.ToModel());
        }

        public async Task<HubServiceModel> GetByIdAsync(string id)
        {
            return (await hubRepository.GetAll()
                .Include(c => c.CreatedBy)
                .Include(c => c.UpdatedBy)
                .Include(c => c.DeletedBy)
                .SingleOrDefaultAsync(c => c.Id == id))?.ToModel();
        }

        public async Task<Hub> InternalGetByIdAsync(string id)
        {
           return await hubRepository.GetAll().SingleOrDefaultAsync(c => c.Id == id);
        }

        public Task<Hub> InternalCreateAsync(Hub model)
        {
            throw new NotImplementedException();
        }

        public async Task<HubServiceModel> UpdateAsync(string id, HubServiceModel model)
        {
            Hub category = await hubRepository.GetAll().SingleOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                throw new NullReferenceException($"No category found with id - {id}.");
            }

            category.Name = model.Name;
            category.Description = model.Description;
            category.HubPhoto = model.HubPhoto != null ? model.HubPhoto.ToEntity() : category.HubPhoto;
            category.BannerPhoto = model.HubPhoto != null ? model.BannerPhoto.ToEntity() : category.BannerPhoto;

            await hubRepository.UpdateAsync(category);

            return category.ToModel();
        }
    }
}