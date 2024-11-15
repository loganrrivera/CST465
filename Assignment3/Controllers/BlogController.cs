using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Assignment3.Code.DataModels;
using Assignment3.Code.Repositories;
using System;

namespace Assignment3.Code.Controllers
{
    [Route("Blog")]
    public class BlogController : Controller
    {
        private readonly IDataEntityRepository<BlogPost> _blogRepository;

        public BlogController(IConfiguration configuration)
        {
            _blogRepository = new BlogDBRepository(configuration);
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var blogPosts = _blogRepository.GetList();
            return View(blogPosts);
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return View(new BlogPostModel());
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(BlogPostModel model)
        {
            Console.WriteLine("Add POST action reached");
            if (ModelState.IsValid)
            {
                Console.WriteLine("Model is valid");
                var blogPost = new BlogPost
                {
                    Author = model.Author,
                    Title = model.Title,
                    Content = model.Content,
                    Timestamp = DateTime.Now
                };
                _blogRepository.Save(blogPost);
                return RedirectToAction("Index");
            }
            Console.WriteLine("Model is invalid");
            return View(model);
        }


        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var blogPost = _blogRepository.Get(id);
            if (blogPost == null) return NotFound();

            var model = new BlogPostModel
            {
                ID = blogPost.ID,
                Author = blogPost.Author,
                Title = blogPost.Title,
                Content = blogPost.Content
            };
            return View(model);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(BlogPostModel model)
        {
            if (ModelState.IsValid)
            {
                var blogPost = new BlogPost
                {
                    ID = model.ID,
                    Author = model.Author,
                    Title = model.Title,
                    Content = model.Content,
                    Timestamp = DateTime.Now
                };
                _blogRepository.Save(blogPost);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
