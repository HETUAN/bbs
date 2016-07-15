
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp.Controllers
{
    public class ArticleController : Controller{
        public IActionResult Index(){
            return View();
        }

        public IActionResult ArtList(){
            return View();
        }

        public IActionResult ArtJsonList(){
            return Json("{}");
        }
    }
}