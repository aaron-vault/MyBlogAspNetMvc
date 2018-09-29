using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyBlogAspNetMvc.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class PostContext : DbContext
    {
        public PostContext() : base("PostCon") { }
        public DbSet<Post> Posts { get; set; }
    }
}