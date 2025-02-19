using BloggingPlatformAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BloggingPlatformAPI.Data
{
    public class BloggingDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTag> PostTags { get; set; }

        public BloggingDbContext(DbContextOptions<BloggingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.TagId });
                entity.HasOne(e => e.Post)
                    .WithMany(e => e.Tags)
                    .HasForeignKey(e => e.PostId);

                entity.HasOne(e => e.Tag)
                   .WithMany(e => e.Posts)
                   .HasForeignKey(e => e.TagId);
            }
                );

        }
    }
}
