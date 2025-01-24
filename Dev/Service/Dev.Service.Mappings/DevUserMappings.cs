using Dev.Data.Models;
using Dev.Service.Models;

namespace Dev.Service.Mappings
{
    public static class DevUserMappings
    {
        public static DevUser ToEntity(this DevUserServiceModel model)
        {
            return new DevUser();
        }

        public static DevUserServiceModel ToModel(this DevUser entity)
        {
            return new DevUserServiceModel
            {
                ForumRole = entity.ForumRole.ToModel(),
                Email = entity.Email,
                Id = entity.Id,
                UserName = entity.UserName
            };
        }
    }
}