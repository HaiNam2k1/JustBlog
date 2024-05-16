using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repositories.Implements
{
    public class CommentRepository : ICommentRepository
    {
        private readonly JustBlogContext db;
        public CommentRepository()
        {
            this.db = new JustBlogContext();
        }
        public void AddComment(Comment comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
        }

        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Comment { Name = commentName, Email = commentEmail, PostId = postId };
            db.Comments.Add(comment);
            db.SaveChanges();
        }

        public void DeleteComment(Comment comment)
        {
            var rs = db.Comments.FirstOrDefault(x=>x.Id == comment.Id);
            if(rs != null)
            {
                db.Comments.Remove(rs);
                db.SaveChanges();
            }
        }

        public void DeleteComment(int commendId)
        {
            var rs = db.Comments.FirstOrDefault(x => x.Id == commendId);
            if (rs != null)
            {
                db.Comments.Remove(rs);
                db.SaveChanges();
            }
        }

        public Comment Find(int commentId)
        {
            var rs = db.Comments.FirstOrDefault(x => x.Id == commentId);
            if (rs != null)
            {
                return rs;
            }
            return null;
        }

        public IList<Comment> GetAllComments()
        {
            return db.Comments.ToList();    
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            var rs = db.Comments.Where(x=>x.PostId == postId).ToList();
            return rs;
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            var rs = db.Comments.Where(x => x.PostId == post.Id).ToList();
            return rs;

        }

        public void UpdateComment(Comment comment)
        {
            var rs = db.Comments.Where(x => x.Id == comment.Id).FirstOrDefault() ;
            if(rs != null)
            {
                rs.Name = comment.Name;
                rs.Email = comment.Email;
                rs.CommentHeader = comment.CommentHeader;
                rs.CommentText = comment.CommentText;
                rs.CommentTime = comment.CommentTime;
                db.SaveChanges();
            }
        }
    }
}
