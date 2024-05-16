using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories.Implements
{
    public class PostRepository : IPostRepository
    {
        private readonly JustBlogContext _context;
        public PostRepository(JustBlogContext just)
        {
            _context = just;
        }
        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public int CountPostsForCategory(string category)
        {
            var cate = _context.Categories.FirstOrDefault(x=>x.Name.Equals(category));
            if (cate != null)
            {
                var rs = _context.Posts.Where(x => x.CategoryId == cate.Id).ToList().Count();
                return rs;
            }
            return 0;

        }

        public int CountPostsForTag(string tag)
        {
            int count = 0;
            var tagfounded = _context.Tags.FirstOrDefault(x => x.Name.Equals(tag));
            if (tagfounded != null)
            {
                var postTags = _context.PostTagsMap.Where(x => x.TagId == tagfounded.Id).ToList();
                var posts = _context.Posts.ToList();
                foreach (var item in postTags)
                {
                    foreach (var post in posts)
                    {
                        if (item.PostId == post.Id)
                        {
                            count++;
                        }

                    }
                }
                return count;
            }
            return 0;
        }

        public void DeletePost(Post post)
        {
            var rs = _context.Posts.FirstOrDefault(x => x.Id == post.Id);
            if(rs != null)
            {
                _context.Posts.Remove(rs);
                _context.SaveChanges();
            }
        }

        public void DeletePost(int postId)
        {
            var rs = _context.Posts.Find(postId);
            if(rs != null)
            {
                _context.Posts.Remove(rs);
                _context.SaveChanges();
            }
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            var rs = _context.Posts.FirstOrDefault(x =>
                    x.PostedOn.Year == year && x.PostedOn.Month == month && x.UrlSlug == urlSlug);
            if( rs != null)
            {
                return rs;

            }
            return null;
        }

        public Post FindPost(int postId)
        {
            var rs = _context.Posts.Find(postId);
            if(rs != null)
            {
                return rs;
            }
            return null;
        }

        public IList<Post> GetAllPosts()
        {
            var rs = _context.Posts.ToList();
            return rs;
        }

        public IList<Post> GetHighestPosts(int size)
        {
            return _context.Posts
                           .OrderByDescending(x => x.RateCount == 0 ? 0 : (decimal)x.TotalRate / x.RateCount)
                           .Take(size)
                           .ToList();
        }

        public IList<Post> GetLatestPost(int size)
        {
         var rs = _context.Posts
        .OrderByDescending(x => x.PostedOn) 
        .Take(size) 
        .ToList(); 
            return rs;
        }
        public IList<Post> GetMostViewedPost(int size)
        {
            return _context.Posts
                           .OrderByDescending(x => x.ViewCount)
                           .Take(size)
                           .ToList();
        }

        public IList<Post> GetPostsByCategory(string category)
        {
            var cate = _context.Categories.FirstOrDefault(x => x.Name.Equals(category));
            if (cate != null)
            {
                var rs = _context.Posts.Where(x => x.CategoryId == cate.Id).ToList();
                return rs;
            }
            return null;
        }

        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            var rs = _context.Posts.Where(p => p.PostedOn.Year == monthYear.Year && p.PostedOn.Month == monthYear.Month).ToList();         
            return rs;
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            int count = 0;
            var rs = new List<Post>();
            var tagfounded = _context.Tags.FirstOrDefault(x => x.Name.Equals(tag));
            if (tagfounded != null)
            {
                var postTags = _context.PostTagsMap.Where(x => x.TagId == tagfounded.Id).ToList();
                var posts = _context.Posts.ToList();
                foreach (var item in postTags)
                {
                    foreach (var post in posts)
                    {
                        if (item.PostId == post.Id)
                        {
                            rs.Add(post);
                        }

                    }
                }
                return rs;
            }
            return null;
        }

        public IList<Post> GetPublisedPosts()
        {
            var rs = _context.Posts
                    .Where(p => p.Published != null) 
                    .ToList();

            return rs;
        }

        public IList<Post> GetUnpublisedPosts()
        {
            var rs = _context.Posts
                  .Where(p => p.Published == null)
                  .ToList();

            return rs;
        }

        public void UpdatePost(Post post)
        {
            var rs = _context.Posts.Find(post.Id);
            if (rs != null)
            {
                rs.Title = post.Title;
                rs.ShortDescription = post.ShortDescription;
                rs.PostContent = post.PostContent;
                rs.UrlSlug = post.UrlSlug;
                rs.Published = post.Published;
                rs.Modified = DateTime.Now;

                rs.CategoryId = post.CategoryId;
             
                
            }
            _context.SaveChanges();
        }
    }
}
