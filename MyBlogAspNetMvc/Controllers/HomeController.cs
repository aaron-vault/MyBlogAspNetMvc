using MyBlogAspNetMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlogAspNetMvc.Controllers
{
    public class HomeController : Controller
    {
        private IPostRepository postRepository;

        public HomeController(IPostRepository repository)
        {
            postRepository = repository;
        }

        public ActionResult Index()
        {
            return View(postRepository.GetPosts());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}