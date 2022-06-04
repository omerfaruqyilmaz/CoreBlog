using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog.BlogLast3Post
{
    public class BlogListDashboard : ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var values = blogManager.GetBlogListWithCategory();
            return View(values);
        }
    }
}
