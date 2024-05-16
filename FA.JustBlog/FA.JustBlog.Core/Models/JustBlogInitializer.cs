using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Models
{
    public class JustBlogInitializer 
    {
        private readonly ModelBuilder modelBuilder;

        public JustBlogInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Post>().HasData(
                   new Post
                   {
                       Id = 1,
                       Title = "First Post",
                       ShortDescription = "Short description of first post",
                       PostContent = "Content of first post",
                       UrlSlug = "first-post",
                       Published = DateTime.Now,
                       PostedOn = DateTime.Now,
                       Modified = DateTime.Now,
                       CategoryId = 1
                   },
              new Post
              {
                  Id = 2,
                  Title = "Second Post",
                  ShortDescription = "Short description of second post",
                  PostContent = "Content of second post",
                  UrlSlug = "second-post",
                  Published = DateTime.Now,
                  PostedOn = DateTime.Now,
                  Modified = DateTime.Now,
                  CategoryId = 2
              },
            new Post
            {
                Id = 3,
                Title = "Third Post",
                ShortDescription = "Short description of third post",
                PostContent = "Content of third post",
                UrlSlug = "third-post",
                Published = DateTime.Now,
                PostedOn = DateTime.Now,
                Modified = DateTime.Now,
                CategoryId = 1
            }


            );
            modelBuilder.Entity<Tag>().HasData(

                new Tag
                {
                    Id = 1,
                    Name = "Technology",
                    UrlSlug = "technology",
                    Description = "Posts related to technology",
                    Count = 2
                },
            new Tag
            {
                Id = 2,
                Name = "Programming",
                UrlSlug = "programming",
                Description = "Posts related to programming",
                Count = 1
            },
            new Tag
            {
                Id = 3,
                Name = "Database",
                UrlSlug = "database",
                Description = "Posts related to database",
                Count = 1
            });

            modelBuilder.Entity<Category>().HasData(
                 new Category
                 {
                     Id = 1,
                     Name = "Technology",
                     UrlSlug = "technology",
                     Description = "Posts related to technology"
                 },
            new Category
            {
                Id = 2,
                Name = "Programming",
                UrlSlug = "programming",
                Description = "Posts related to programming"
            },
            new Category
            {
                Id = 3,
                Name = "Database",
                UrlSlug = "database",
                Description = "Posts related to database"
            }
                );
            modelBuilder.Entity<PostTagMap>().HasData(
            new PostTagMap { PostId = 1, TagId = 1 },
            new PostTagMap { PostId = 1, TagId = 2 },
            new PostTagMap { PostId = 2, TagId = 1 }
            );
        }
    }
}