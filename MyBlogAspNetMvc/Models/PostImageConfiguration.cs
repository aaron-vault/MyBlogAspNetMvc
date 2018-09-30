using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MyBlogAspNetMvc.Models
{
    public class PostImageConfiguration : EntityTypeConfiguration<PostImage>
    {
        public PostImageConfiguration()
        {
            ToTable("PostAvatars");
            HasOptional(s => s.Post)
                .WithOptionalPrincipal(x => x.Avatar);
        }
    }
}