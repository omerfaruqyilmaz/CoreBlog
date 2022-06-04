using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog Id";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int blogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.Id;
                    workSheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }

        }

       public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogModels = new List<BlogModel>();
            using(var context=new Context())
            {
                blogModels = context.Blogs.Select(x => new BlogModel
                {
                    Id = x.BlogId,
                    BlogName = x.BlogTitle
                }).ToList();

            };
            return blogModels;

        }

        public IActionResult BlogListExcel()
        {
            return View();

        }
    }
}
