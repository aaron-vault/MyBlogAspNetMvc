using MyBlogAspNetMvc.Models;
using MyBlogAspNetMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyBlogAspNetMvc.Domains
{
    public class PostAvatarRepository : IPostAvatarRepository
    {
        /**
         * Заготовка для добавления 
         * изображений внутри поста.
         */

        private PostContext context = new PostContext();
        private bool disposed = false;

        public async Task<PostImage> Create(PostImage avatar)
        {
            context.PostAvatars.Add(avatar);
            await context.SaveChangesAsync();
            return avatar;
        }

        public async Task<PostImage> Read(int id)
        {
            PostImage avatar = await context.PostAvatars.FindAsync(id);
            return avatar;
        }

        public async Task<PostImage> Update(PostImage avatar)
        {
            context.Entry(avatar).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return avatar;
        }

        public async Task<PostImage> Delete(int id)
        {
            PostImage avatar = await context.PostAvatars.FindAsync(id);
            context.PostAvatars.Remove(avatar);
            await context.SaveChangesAsync();
            return avatar;
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