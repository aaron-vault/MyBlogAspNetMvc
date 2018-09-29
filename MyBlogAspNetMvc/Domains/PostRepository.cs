using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MyBlogAspNetMvc.Models;
using MyBlogAspNetMvc.Repositories;

namespace MyBlogAspNetMvc.Domains
{
    public class PostRepository : IPostRepository, IDisposable
    {
        private PostContext context = new PostContext();
        private bool disposed = false;

        public PostRepository() { }

        public IEnumerable<Post> GetPosts()
        {
            return context.Posts.ToList();
        }

        public Post GetPostById(int id)
        {
            return context.Posts.Find(id);
        }

        public void InsertPost(Post post)
        {
            Post item = context.Posts.Add(post);
            //id = item.Id;
        }

        public void DeletePost(int id)
        {
            Post post = context.Posts.Find(id);
            context.Posts.Remove(post);
        }

        public void UpdatePost(Post post)
        {
            context.Entry(post).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}