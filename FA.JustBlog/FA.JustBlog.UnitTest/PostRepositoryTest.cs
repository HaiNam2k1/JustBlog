using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Implements;
using FA.JustBlog.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.UnitTest
{
    [TestFixture]
    public class PostRepositoryTest
    {
        private IPostRepository _repository;
        private JustBlogContext _context;
        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<JustBlogContext>()
               .UseSqlServer("Data Source=localhost;Initial Catalog=JustBlog;User ID=sa;Password=123456;Integrated Security=True;Trusted_Connection=True; TrustServerCertificate=True")
               .Options;
            _context = new JustBlogContext(options);
            _repository = new PostRepository(_context);
        }
        [Test]
        public void AddPost_Successfull()
        {
            //Arrange
            var post = new Post { Title = "Second Post",ShortDescription = "", PostContent="", UrlSlug="", Published=true, PostedOn= DateTime.UtcNow, Modified = DateTime.UtcNow,
                CategoryId = 1
            };
            //Act
            _repository.AddPost(post);
            var rs = _context.Posts.Where(x => x.Title.Equals(post.Title)).FirstOrDefault();
            //Assert
            Assert.AreEqual(post.Title, rs.Title);

        }
        [Test]
        public void GetAllPosts_GreaterThanZeroAndNotNull()
        {
            //Arrange
            //Act
            var rs = _repository.GetAllPosts();
            //Assert
            Assert.IsNotNull(rs);
            Assert.Greater(rs.Count(), 0);
        }
        [Test]
        public void UpdatePost_Successfull() {
            //Arrange
            var post = new Post {Id = 1,
                Title = "Second Post",
                ShortDescription = "",
                PostContent = "",
                UrlSlug = "",
                Published = true,
                PostedOn = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                CategoryId = 1
            };
            //Act
            _repository.UpdatePost(post);
            var rs = _context.Posts.FirstOrDefault(x => x.Id == post.Id);
            //Assert
            Assert.AreEqual(post.Title, rs.Title);
        }
    }
}
