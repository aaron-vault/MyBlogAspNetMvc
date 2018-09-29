using MyBlogAspNetMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlogAspNetMvc.Domains;

namespace MyBlogAspNetMvc.Repositories
{
    public interface IPostRepository : IDisposable
    {
        IEnumerable<Post> GetPosts();
        Post GetPostById(int id);
        void InsertPost(Post post);
        void DeletePost(int id);
        void UpdatePost(Post post);
        void Save();
    }
}
