using Dev.Data.Models;
using Dev.Service.Models;
using System.Xml.Linq;

namespace Dev.Service.Mappings
{
    public static class DevThreadMappings
    {
        public static DevThread ToEntity(this ThreadServiceModel model)
        {
            return new DevThread
            {
                Title = model.Title,
                Content = model.Content,
                Hub = model.Hub?.ToEntity(),
                Tags = model.Tags?.Select(t => t.ToEntity()).ToList()
            };
        }

        public static ThreadServiceModel ToModel(this DevThread entity)
        {
            return new ThreadServiceModel
            {
                Id = entity.Id,
                Title = entity.Title,
                Content = entity.Content,
                Hub = entity.Hub?.ToModel(),
                Tags = entity.Tags?.Select(t => t.ToModel()).ToList(),
              //  Reactions = entity.Reactions?.Select(reaction => reaction.ToModel()).ToList(),
                Comments = entity.Comments?.Select(comment => comment.ToModel(UserThreadCommentMappingsContext.Thread)).ToList(),
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