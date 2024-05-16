using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories.Implements
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly JustBlogContext db;
        public CategoryRepository(JustBlogContext just)
        {
            db = just;
        }
        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
           var rs = db.Categories.FirstOrDefault(x=>x.Id == category.Id);
            if(rs != null) {
                db.Categories.Remove(rs);
                db.SaveChanges();
            }
        }

        public void DeleteCategory(int categoryId)
        {
            var result = db.Categories.FirstOrDefault(x=>x.Id == categoryId);
            if(result != null)
            {
                db.Categories.Remove(result);
                db.SaveChanges();

            }
        }

        public Category Find(int categoryId)
        {
            var result = db.Categories.Find(categoryId);
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public IList<Category> GetAllCategories()
        {
            var results = db.Categories.ToList();
            return results;
        }

        public void UpdateCategory(Category category)
        {
            var result = db.Categories.Find(category.Id);
            if(result != null)
            {
                result.Name = category.Name;
                result.Description = category.Description;
                result.UrlSlug = category.UrlSlug;
            }
            db.SaveChanges();

        }
    }
}
