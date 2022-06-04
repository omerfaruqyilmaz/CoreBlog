using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Repository());
        Context context = new Context();
        public IActionResult Inbox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var values = messageManager.GetInboxListByWriter(writerId);
            return View(values);
        }

        public IActionResult Sendbox()
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            var values = messageManager.GetSendboxWithMessageByWriter(writerId);
            return View(values);

        }

        public IActionResult ComposeMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ComposeMessage(Message2 p)
        {
            var userName = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId = context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterId).FirstOrDefault();
            p.SenderId = writerId;
            p.ReceiverId = 2;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.MessageStatus = true;
            messageManager.AddT(p);
            return RedirectToAction("Sendbox");
        }
    }
}
