using Dev.Data.Models;
using Dev.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Service.Mappings
{
    public static class ReactionMappings
    {
        public static Reaction ToEntity(this ReactionServiceModel model)
        {
            return new Reaction
            {
                Label = model.Label,
                Emote = model.Emote.ToEntity()
            };
        }

        public static ReactionServiceModel ToModel(this Reaction entity)
        {
            return new ReactionServiceModel
            {
                Id = entity.Id,
                Label = entity.Label,
                Emote = entity.Emote?.ToModel(),
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
