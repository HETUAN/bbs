using System;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp.Controllers
{
    public class HomeController : Controller{

        public IActionResult Index(){
            return RedirectToAction("Index", "Article");
        }

        public IActionResult About(){
            var useragent=Request.Headers["User-Agent"];
            return Content(useragent+"\r\nabout by linezero");
            //return View("About Page!");
        }
    }
}