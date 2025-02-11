using Dev.Data.Models;
using Dev.Service.Models;
using Microsoft.EntityFrameworkCore;
using Dev.Data.Repositories;
using Dev.Service.Mappings;

namespace Dev.Service
{
    public class HubService : IHubService
    {
        private readonly HubRepository categoryRepository;

        public HubService(HubRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<HubServiceModel> CreateAsync(HubServiceModel model)
        {
            Hub category = model.ToEntity();

            await this.categoryRepository.CreateAsync(category);

            return category.ToModel();
        }

        public async Task<HubServiceModel> DeleteAsync(string id)
        {
            Hub category = await this.categoryRepository.GetAll().SingleOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                throw new NullReferenceException($"No category found with id - {id}.");
            }

            await this.categoryRepository.DeleteAsync(category);

            return category.ToModel();
        }

        public IQueryable<HubServiceModel> GetAll()
        {
            return this.categoryRepository.GetAll()
                .Include(c => c.CreatedBy)
                .Include(c => c.UpdatedBy)
                .Include(c => c.DeletedBy)
                .Select(c => c.ToModel());
        }

        public async Task<HubServiceModel> GetByIdAsync(string id)
        {
            return (await this.categoryRepository.GetAll()
                .Include(c => c.CreatedBy)
                .Include(c => c.UpdatedBy)
                .Include(c => c.DeletedBy)
                .SingleOrDefaultAsync(c => c.Id == id))?.ToModel();
        }

        public async Task<HubServiceModel> UpdateAsync(string id, HubServiceModel model)
        {
            Hub category = await this.categoryRepository.GetAll().SingleOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                throw new NullReferenceException($"No category found with id - {id}.");
            }

            category.Name = model.Name;
            category.Description = model.Description;
            category.HubPhoto = model.HubPhoto != null ? model.HubPhoto.ToEntity() : category.HubPhoto;
            category.BannerPhoto = model.HubPhoto != null ? model.BannerPhoto.ToEntity() : category.BannerPhoto;

            await this.categoryRepository.UpdateAsync(category);

            return category.ToModel();
        }
    }
}