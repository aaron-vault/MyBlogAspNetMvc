﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlogAspNetMvc.Models;

namespace MyBlogAspNetMvc.Repositories
{
    public interface IPostAvatarRepository : ICrudRepository<PostImage>, IDisposable
    {
    }
}
