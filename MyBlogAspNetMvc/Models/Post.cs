using MyBlogAspNetMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlogAspNetMvc.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Author { get; set; }
    }
}