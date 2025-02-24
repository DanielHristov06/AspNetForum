using Dev.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Dev.Web.Seed
{
    public static class DataBaseSeedUtilities
    {
        public static void UseDatabaseSeed(this WebApplication app)
        {
            SeedRoles(app);
        }
        public static void SeedRoles(WebApplication app)
        {
            using (var serviceScope = app.Services.CreateScope())
            {
                using (var devDbContext = serviceScope.ServiceProvider.GetRequiredService<DevDbContext>())
                {
                    devDbContext.Database.Migrate();
                    if (devDbContext.Roles.Count() == 0)
                    {
                        IdentityRole adminRole = new IdentityRole();
                        adminRole.Name = "Administrator";
                        adminRole.NormalizedName = adminRole.Name.ToUpper();

                        IdentityRole moderatorRole = new IdentityRole();
                        moderatorRole.Name = "Moderator";
                        moderatorRole.NormalizedName = moderatorRole.Name.ToUpper();

                        IdentityRole userRole = new IdentityRole();
                        userRole.Name = "User";
                        userRole.NormalizedName = userRole.Name.ToUpper();

                        devDbContext.Add(adminRole);
                        devDbContext.Add(moderatorRole);
                        devDbContext.Add(userRole);

                        devDbContext.SaveChanges();
                    }
                }
            }
        }
    }
}