using Dev.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Service.User
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IUserStore<DevUser> userStore;

        public UserContextService(
            IHttpContextAccessor httpContextAccessor,
            IUserStore<DevUser> userStore)
        {
            _httpContextAccessor = httpContextAccessor;
            this.userStore = userStore;
        }

        public async Task<DevUser> GetCurrentUserAsync()
        {
            string? userId = this._httpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return await this.userStore.FindByIdAsync(userId, CancellationToken.None);
        }
    }
}
