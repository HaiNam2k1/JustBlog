using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories.Implements
{
    public class TagRepository : ITagRepository
    {
        private readonly JustBlogContext _context;
        public TagRepository(JustBlogContext just)
        {
            _context = just;
        }
        public void AddTag(Tag Tag)
        {
            _context.Tags.Add(Tag);
            _context.SaveChanges();
        }

        public void DeleteTag(Tag Tag)
        {
            var rs = _context.Tags.FirstOrDefault(x => x.Id == Tag.Id);
            if (rs != null)
            {
                _context.Tags.Remove(rs);
                _context.SaveChanges();
            }
        }

        public void DeleteTag(int TagId)
        {
            var result = _context.Tags.Find(TagId);
            if (result != null)
            {
                _context.Tags.Remove(result);
                _context.SaveChanges();
            }
        }

        public Tag Find(int TagId)
        {
            var result = _context.Tags.Find(TagId);
            if(result != null) {
                return result;
            }
            return null;
        }

        public IList<Tag> GetAllTags()
        {
            var results = _context.Tags.ToList();
            return results;
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            var result = _context.Tags.FirstOrDefault(x=>x.UrlSlug.Equals(urlSlug));
            if (result != null) {
                return result;
            }
            return null;
        }

        public void UpdateTag(Tag Tag)
        {
            var result = _context.Tags.FirstOrDefault(x=>x.Id == Tag.Id);
            if( result != null)
            {
                result.Name = Tag.Name;
                result.Description = Tag.Description;
                result.UrlSlug = Tag.UrlSlug;   
                result.Count = Tag.Count;
            }
            _context.SaveChanges();

        }
    }
}
