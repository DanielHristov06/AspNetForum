using Dev.Service.Models;
using Dev.Data.Models;

namespace Dev.Service.Mappings
{
    public static class AttachmentMapping
    {
        public static Attachment ToEntity(this AttachmentServiceModel model)
        {
            return new Attachment
            {
                CloudUrl = model.CloudUrl
            };
        }

        public static AttachmentServiceModel ToModel(this Attachment entity)
        {
            return new AttachmentServiceModel
            {
                Id = entity.Id,
                CloudUrl = entity.CloudUrl
            };
        }
    }
}