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
    public class TagRepositoryTest
    {
        private ITagRepository _repository;
        private JustBlogContext _context;
        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<JustBlogContext>()
               .UseSqlServer("Data Source=localhost;Initial Catalog=JustBlog;User ID=sa;Password=123456;Integrated Security=True;Trusted_Connection=True; TrustServerCertificate=True")
               .Options;
            _context = new JustBlogContext(options);
            _repository = new TagRepository(_context);
        }
        [Test]
        public void AddTag_Successfull()
        {
            //Arrange
            var tag = new Tag { Name="Tag3", UrlSlug ="", Description ="", Count = 1};
            //Act
            _repository.AddTag(tag);
            var rs = _context.Tags.Where(x => x.Name.Equals(tag.Name)).FirstOrDefault();
            //Assert
            Assert.AreEqual(tag.Name, rs.Name);

        }
        [Test]
        public void UpdateTag_Successfull() {
            //Arrange
            var tag = new Tag { Id = 1, Name = "Tag3", UrlSlug = "", Description = "", Count = 1 };
            //Act
            _repository.UpdateTag(tag);
            var rs = _context.Tags.FirstOrDefault(x => x.Id == tag.Id);
            //Assert
            Assert.AreEqual(tag.Name, rs.Name);
        }
        [Test]
        public void GetAllTags_GreaterThanZeroAndNotNull()
        {
            //Arrange
            //Act
            var rs = _repository.GetAllTags();
            //Assert
            Assert.IsNotNull(rs);
            Assert.Greater(rs.Count(), 0);
        }
    }
}
