using Dev.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dev.Web.Data
{
    public class DevDbContext : IdentityDbContext<DevUser>
    {
        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<DevThread> Threads { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Reaction> Reactions { get; set; }

        public DbSet<DevRole> ForumRoles { get; set; }

        public DevDbContext(DbContextOptions<DevDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<UserThreadReaction>()
                .HasOne(utr => utr.Thread)
                .WithMany(t => t.Reactions)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}