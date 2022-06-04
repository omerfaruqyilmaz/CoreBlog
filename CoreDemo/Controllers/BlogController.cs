using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    
    public class BlogController : Controller
    {

        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        Context context = new Context();
        [AllowAnonymous]
        public IActionResult Index()
        {

            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }

        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = blogManager.GetBlogById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            
            var values= blogManager.GetCategoryName(writerId);
            return View(values);
        }

        public IActionResult BlogAdd()
        {         
            List<SelectListItem> selectListItems = (from x in categoryManager.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryId.ToString()
                                                    }).ToList();
            ViewBag.cv = selectListItems;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {

            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();

            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(blog);
            if (results.IsValid)
            {
                blog.BlogStatus = true;
                blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                blog.WriterId = writerId;
                blogManager.AddT(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();     
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogValue = blogManager.TGetById(id);
            blogManager.DeleteT(blogValue);
            return RedirectToAction("BlogListByWriter");
        }

        public IActionResult EditBlog(int id)
        {
            var blogValue = blogManager.TGetById(id);
            List<SelectListItem> categoryValue = (from x in categoryManager.GetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.CategoryName,
                                                        Value = x.CategoryId.ToString()
                                                    }).ToList();
            ViewBag.cv = categoryValue;
            return View(blogValue);
        }

        [HttpPost]

        public IActionResult EditBlog(Blog blog)
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            blog.WriterId = writerId;
            blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
            blogManager.UpdateT(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
