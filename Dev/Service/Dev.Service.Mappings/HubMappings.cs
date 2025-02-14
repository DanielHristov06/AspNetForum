using Dev.Data.Models;
using Dev.Service.Models;

namespace Dev.Service.Mappings
{
    public static class HubMappings
    {
        public static Hub ToEntity(this HubServiceModel model)
        {
            return new Hub
            {
                Name = model.Name,
                Description = model.Description,
                Tags = model.Tags.Select(tag => tag.ToEntity()).ToList(),
                HubPhoto = model.HubPhoto?.ToEntity(),
                BannerPhoto = model.BannerPhoto?.ToEntity()
            };
        }

        public static HubServiceModel ToModel(this Hub entity)
        {
            return new HubServiceModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Tags = entity.Tags.Select(tag => tag.ToModel()).ToList(),
                HubPhoto = entity.HubPhoto?.ToModel(),
                BannerPhoto = entity.BannerPhoto?.ToModel(),
                CreatedOn = entity.CreatedOn,
                UpdatedOn = entity.UpdatedOn,
                DeletedOn = entity.DeletedOn,
                CreatedBy = entity.CreatedBy.ToModel(),
                UpdatedBy = entity.UpdatedBy?.ToModel(),
                DeletedBy = entity.DeletedBy?.ToModel()
            };
        }
    }
}