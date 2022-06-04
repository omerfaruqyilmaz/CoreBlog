using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
           // ViewBag.v1 = blogManager.GetList().Count();
            ViewBag.v1 = context.Blogs.OrderByDescending(x=>x.BlogId).Select(x=>x.BlogTitle).Take(1).FirstOrDefault();
            
            return View();
        }
    }
}
