
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp.Controllers
{
    public class ArticleController : Controller{
        public IActionResult Index(){
            Services.ArticleService artServices = new Services.ArticleService();
            return View(artServices.GetList());
        }

        public IActionResult Art(int ArtId){
            Services.ArtDetailService artDetailServices = new Services.ArtDetailService();
            return Content(artDetailServices.GetModel(ArtId));
        }

        public IActionResult ArtList(){
            Services.ArticleService artServices = new Services.ArticleService();
            return View(artServices.GetList());
        }

        public IActionResult ArtJsonList(){
            return Json("{}");
        }
    }
}