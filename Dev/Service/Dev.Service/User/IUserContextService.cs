using Dev.Data.Models;

namespace Dev.Service.User
{
    public interface IUserContextService
    {
        Task<DevUser> GetCurrentUserAsync();
    }
}
