using System;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp.Controllers
{
    public class AboutController : Controller{
        public IActionResult Index(){
            return View();
        }
    }
}