using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Implements;
using FA.JustBlog.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.UnitTest
{
    [TestFixture]
    public class CategoryRepositoryTest
    {
        private ICategoryRepository _repository;
        private JustBlogContext _context;

        [SetUp]
        public void SetUp()
        {
            var options = new DbContextOptionsBuilder<JustBlogContext>()
                .UseSqlServer("Data Source=localhost;Initial Catalog=JustBlog;User ID=sa;Password=123456;Integrated Security=True;Trusted_Connection=True; TrustServerCertificate=True")
                .Options;
            _context = new JustBlogContext(options);
            _repository = new CategoryRepository(_context);
        }

        [Test]
        public void AddCategory_Successfull()
        {
            // Arrange
            var category = new Category { Name = "Category1", UrlSlug = "", Description = "ABC" };   
            
            // Act
            _repository.AddCategory(category);
            var rs = _context.Categories.Where(x=>x.Name.Equals(category.Name)).FirstOrDefault();
            // Assert
            Assert.AreEqual(category.Name, rs.Name);
        }

    
        [Test]
        public void UpdateCategory_Successfull()
        {
            //Arrange
            var category = new Category { Id = 1, Name = "Category2", UrlSlug = "", Description = "ABC" };
            //Act
            _repository.UpdateCategory(category);
            var rs = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            //Assert
            Assert.AreEqual(category.Name, rs.Name);
        }

        [Test]
        public void GetCategories_GreaterThanZeroAndNotNull()
        {
            //Arrange
            //Act
           var rs =  _repository.GetAllCategories();
            //Assert
            Assert.IsNotNull(rs);
            Assert.Greater(rs.Count(), 0);
        }

    }
}
