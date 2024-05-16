using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FA.JustBlog.Core.Models
{
    public class JustBlogContext : DbContext
    {

        public JustBlogContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=JustBlog;uid=sa;pwd=123456;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }

        public JustBlogContext(DbContextOptions<JustBlogContext> options) : base(options)
        {
        }

        public  DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTagMap> PostTagsMap { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTagMap>()
             .HasKey(pt => new { pt.PostId, pt.TagId });

            modelBuilder.Entity<PostTagMap>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTagMaps)
                .HasForeignKey(pt => pt.PostId);

            modelBuilder.Entity<PostTagMap>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTagMaps)
                .HasForeignKey(pt => pt.TagId);

            base.OnModelCreating(modelBuilder);
            new JustBlogInitializer(modelBuilder).Seed();
        }

    }
}