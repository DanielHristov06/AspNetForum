namespace Dev.Data.Models
{
    public class UserThreadReaction : BaseEntity
    {
        public DevUser User { get; set; }

        public DevThread Thread { get; set; }

        public Reaction Reaction { get; set; }

        
    }
}