﻿using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoreDemo.Controllers
{
    public class DashboardController : Controller
    {
        
        public IActionResult Index()
        {
            Context context = new Context();
            var userName = User.Identity.Name;           
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.v1 = context.Blogs.Count().ToString();
            ViewBag.v2 = context.Blogs.Where(x=>x.WriterId==writerId).Count();
            ViewBag.v3 = context.Comments.Where(x=>x.BlogId==4).Count();
            
            return View();
        }
    }
}
