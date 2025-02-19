using Dev.Data.Models;
using Dev.Data.Repositories;
using Dev.Service.Mappings;
using Dev.Service.Models;

namespace Dev.Service.Tag
{
    public class DevTagService : IDevTagService
    {
        private readonly DevTagRepository devTagRepository;

        public DevTagService(DevTagRepository devTagRepository)
        {
            this.devTagRepository = devTagRepository;
        }

        public async Task<DevTagServiceModel> CreateAsync(DevTagServiceModel model)
        {
            return (await this.devTagRepository.CreateAsync(model.ToEntity())).ToModel();
        }

        public async Task<DevTag> InternalCreateAsync(DevTag entity)
        {
            return await this.devTagRepository.CreateAsync(entity);
        }

        public Task<DevTagServiceModel> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<DevTagServiceModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<DevTagServiceModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<DevTagServiceModel> UpdateAsync(string id, DevTagServiceModel model)
        {
            throw new NotImplementedException();
        }

        public Task<DevTag> InternalGetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}