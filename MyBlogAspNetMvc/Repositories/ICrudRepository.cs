using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogAspNetMvc.Repositories
{
    public interface ICrudRepository<T>
    {
        Task<T> Create(T item);
        Task<T> Read(int id);
        Task<T> Update(T item);
        Task<T> Delete(int id);
    }
}
