﻿using Dev.Data.Models;
using Dev.Service.Models;

namespace Dev.Service.Mappings
{
    public enum UserThreadReactionMappingsContext
    {
        Thread,
        Reaction,
        User
    }

    public static class UserThreadReactionMappings
    {
        public static UserThreadReactionServiceModel ToModel(this UserThreadReaction entity, UserThreadReactionMappingsContext context, bool IsDeleted = false)
        {
            return new UserThreadReactionServiceModel
            {
                Id = entity.Id,
                Reaction = ShouldMapReaction(context) ? entity.Reaction?.ToModel() : null,
                Thread = ShouldMapThread(context) ? entity.Thread?.ToModel() : null,
                User = ShouldMapUser(context) ? entity.User?.ToModel() : null,
                IsDeleted = IsDeleted
            };
        }

        private static bool ShouldMapReaction(UserThreadReactionMappingsContext context)
        {
            return context == UserThreadReactionMappingsContext.Thread || context == UserThreadReactionMappingsContext.User;
        }

        private static bool ShouldMapThread(UserThreadReactionMappingsContext context)
        {
            return context == UserThreadReactionMappingsContext.Reaction || context == UserThreadReactionMappingsContext.User;
        }

        private static bool ShouldMapUser(UserThreadReactionMappingsContext context)
        {
            return context == UserThreadReactionMappingsContext.Thread || context == UserThreadReactionMappingsContext.Reaction;
        }
    }
}
