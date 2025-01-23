using Dev.Service.Models;

namespace Dev.Service.Models
{
    public class DevRoleServiceModel : BaseServiceModel
    {
        public const string DevRoleDefaultAuthority = "User"; 

        public string Label { get; set; }

        public string Color { get; set; }

        public string Authority { get; set; } = DevRoleDefaultAuthority;
    }
}