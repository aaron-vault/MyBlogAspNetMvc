using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlogAspNetMvc.Repositories;
using MyBlogAspNetMvc.Models;
using MyBlogAspNetMvc.Domains;
using System.Data;
using System.IO;

namespace MyBlogAspNetMvc.Controllers
{
    public class PostController : Controller
    {
        private IPostRepository postRepository;

        public PostController(IPostRepository repository)
        {
            postRepository = repository;
        }

        //
        // GET: Post

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Details/{id}

        public ViewResult Details(int id)
        {
            Post post = postRepository.GetPostById(id);
            return View(post);
        }

        //
        // GET: /Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title, Description, Author")]
                    Post post, HttpPostedFileBase avatar)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    post.CreatedAt = DateTime.Now;
                    post.Avatar = new PostImage { Img = avatar.FileName.ToString() };
                    postRepository.InsertPost(post);
                    postRepository.Save();

                    string fileName = Path.GetFileName(avatar.FileName);
                    avatar.SaveAs(Server.MapPath($"~/Files/{fileName}"));

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Неудалось сохранить изменения! [Create]");
            }

            return View(post);
        }

        //
        // GET: /Edit/{id}

        public ActionResult Edit(int id)
        {
            Post post = postRepository.GetPostById(id);
            return View(post);
        }

        //
        // POST: /Edit/{id}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="Id, Title, Description, Author")] Post post, DateTime createdAt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    post.CreatedAt = createdAt;
                    post.UpdatedAt = DateTime.Now;
                    postRepository.UpdatePost(post);
                    postRepository.Save();
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Неудалось сохранить изменения! [Edit]");
            }

            return View(post);
        }

        //
        // GET: /Delete/{id}

        public ActionResult Delete(int id)
        {
            try
            {
                postRepository.DeletePost(id);
                postRepository.Save();
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Неудалось удалить запись! [Delete]");
            }

            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            postRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}