
namespace Dev.Data.Models
{
    public class DevRole : BaseEntity
    {
        public const string DevDefaultAuthority = "User";
        public string Label { get; set; }

        public string Color { get; set; }

        public string Authority { get; set; } = DevDefaultAuthority;
    }
}
