using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MyBlogAspNetMvc.Models
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            ToTable("Posts");
            HasOptional(s => s.Avatar)
                .WithOptionalPrincipal(x => x.Post);
        }
    }
}