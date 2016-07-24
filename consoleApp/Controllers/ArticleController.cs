
using System;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp.Controllers
{
    public class ArticleController : Controller{

        #region 前台


        public IActionResult Index(){
            Services.ArticleService artServices = new Services.ArticleService();
            return View(artServices.GetList());
        }
        
        public IActionResult ArtDet(int id){
            Services.ArtDetailService artDetailServices = new Services.ArtDetailService();
            if(id==0)
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

        #endregion
        
        #region 后台管理
        
        public IActionResult ArtManage(){
            int UserID = GetUserID();
            if(UserID>=0){
                return RedirectToAction("Index", "User");
            }  
            Services.ArticleService artSer = new Services.ArticleService();
            //artSer.GetListByID();
            
            return View(artSer.GetListByUserID(UserID));
        }

        public IActionResult ArtEdit(int id){
            //
            if(id==0)
            {
                return RedirectToAction("Index", "User");
            }
            Services.ArticleService artSer = new Services.ArticleService();
            var data = artSer.GetModelByID(id);
            return View(data);
        }
        
        // 验证用户登录 返回0 未登录 返回>0用户ID
        private int GetUserID()
        {
            try{
                //
                byte[] bts;
                HttpContext.Session.TryGetValue("User", out bts);
                if (bts != null && bts.Length > 0)
                {
                    return Convert.ToInt32(System.Text.Encoding.UTF8.GetString(bts));
                }
                else
                {
                    return 0;
                }
            }catch(Exception ex){
                throw ex;
            }
        }


        #endregion
    }
}