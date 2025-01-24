using Dev.Data.Models;
using Dev.Service.Models;

namespace Dev.Service.Mappings
{
    public static class DevRoleMappings
    {
        public static DevRole ToEntity(this DevRoleServiceModel model)
        {
            return new DevRole
            {
                Label = model.Label,
                Color = model.Color,
                Authority = model.Authority
            };
        }

        public static DevRoleServiceModel ToModel(this DevRole entity)
        {
            return new DevRoleServiceModel
            {
                Id = entity.Id,
                Label = entity.Label,
                Color = entity.Color,
                Authority = entity.Authority
            };
        }
    }
}