using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlogAspNetMvc.Models
{
    public class PostImage
    {
        [Key]
        [ForeignKey("Post")]
        public int Id { get; set; }
        public virtual Post Post { get; set; }
        public string Img { get; set; }
    }
}