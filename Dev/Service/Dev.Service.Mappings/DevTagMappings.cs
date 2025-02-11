using Dev.Data.Models;
using Dev.Service.Models;

namespace Dev.Service.Mappings
{
    public static class DevTagMappings
    {
        public static DevTag ToEntity(this DevTagServiceModel model)
        {
            return new DevTag
            {
                Label = model.Label
            };
        }

        public static DevTagServiceModel ToModel(this DevTag entity)
        {
            return new DevTagServiceModel
            {
                Id = entity.Id,
                Label = entity.Label,
                CreatedOn = entity.CreatedOn,
                UpdatedOn = entity.UpdatedOn,
                DeletedOn = entity.DeletedOn,
                CreatedBy = entity.CreatedBy.ToModel(),
                UpdatedBy = entity.UpdatedBy.ToModel(),
                DeletedBy = entity.DeletedBy.ToModel()
            };
        }
    }
}