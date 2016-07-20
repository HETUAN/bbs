
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp.Controllers
{
    public class ArticleController : Controller{
        public IActionResult Index(){
            Services.ArticleService artServices = new Services.ArticleService();
            return View(artServices.GetList());
        }
        
        public IActionResult ArtDet(int id){
            Services.ArtDetailService artDetailServices = new Services.ArtDetailService();
            if(id==null||id==0)
            {
                return RedirectToAction("Index");
            }
            string mdstr = artDetailServices.GetModel(id);
            ViewData["mdstr"] = mdstr;
            return View();
        }
        public IActionResult Art(int id){
            Services.ArtDetailService artDetailServices = new Services.ArtDetailService();
            return Content(artDetailServices.GetModel(id));
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