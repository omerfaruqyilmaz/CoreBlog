using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryModel> list = new List<CategoryModel>();
            list.Add(new CategoryModel
            {
                CategoryName = "Yazılım",
                CategoryCount = 13

            });
            list.Add(new CategoryModel
            {
                CategoryName = "Spor",
                CategoryCount = 23

            });
            list.Add(new CategoryModel
            {
                CategoryName = "Teknoloji",
                CategoryCount = 3

            });
            return Json(new { jsonList = list });
        }
    }
}
