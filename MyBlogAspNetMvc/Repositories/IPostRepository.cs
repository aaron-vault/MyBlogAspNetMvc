using MyBlogAspNetMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlogAspNetMvc.Domains;
using System.Web;

namespace MyBlogAspNetMvc.Repositories
{
    public interface IPostRepository : IDisposable
    {
        IPostAvatarRepository Avatar { get; }
        IEnumerable<Post> GetPosts();
        Post GetPostById(int id);
        void InsertPost(Post post);
        void DeletePost(int id);
        void UpdatePost(Post post);
        void Save();
    }
}
