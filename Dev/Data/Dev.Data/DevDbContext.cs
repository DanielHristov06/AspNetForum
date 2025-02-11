using Dev.Data.Extensions;
using Dev.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dev.Data
{
    public class DevDbContext : IdentityDbContext<DevUser>
    {
        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<Hub> Hubs { get; set; }

        public DbSet<DevThread> Threads { get; set; }

        public DbSet<DevThread> Tags { get; set; }

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

            builder.Entity<DevUser>()
               .HasOne(u => u.ForumRole)
               .WithMany()
               .OnDelete(DeleteBehavior.NoAction);

            builder.ConfigureMetadataEntity<DevRole>();
            builder.ConfigureMetadataEntity<DevTag>();

            builder.Entity<Hub>()
                .HasOne(gc => gc.HubPhoto)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Hub>()
                .HasOne(gc => gc.BannerPhoto)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Hub>()
                .HasMany(gc => gc.Tags)
                .WithMany();

            builder.Entity<DevThread>()
                .HasMany(gc => gc.Tags)
                .WithMany();


            base.OnModelCreating(builder);
        }
    }
}