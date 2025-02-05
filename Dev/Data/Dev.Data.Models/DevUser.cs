using Microsoft.AspNetCore.Identity;

namespace Dev.Data.Models
{
    public class DevUser : IdentityUser
    {
        public DevRole? ForumRole { get; set; }
    }
}