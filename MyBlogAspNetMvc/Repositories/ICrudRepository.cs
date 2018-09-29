using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogAspNetMvc.Repositories
{
    public interface ICrudRepository<T>
    {
        void Create(T item);
        T Read(int id);
        void Update(T item);
        void Delete(int id);
    }
}
