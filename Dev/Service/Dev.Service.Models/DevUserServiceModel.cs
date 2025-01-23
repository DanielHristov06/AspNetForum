using Microsoft.AspNetCore.Identity;

namespace Dev.Service.Models
{
    public class DevUserServiceModel : IdentityUser
    {
        public DevRoleServiceModel ForumRole { get; set; }
    }
}