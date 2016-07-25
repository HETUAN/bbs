using System;
using Microsoft.AspNetCore.Mvc;
using ConsoleApp.Models;
using ConsoleApp.Services;

namespace ConsoleApp.Controllers
{
    public class ArticleController : Controller
    {

        #region 前台

        // 文章列表
        public IActionResult Index()
        {
            Services.ArticleService artServices = new Services.ArticleService();
            return View(artServices.GetList());
        }

        // 文章查看
        public IActionResult ArtDet(int id)
        {
            Services.ArtDetailService artDetailServices = new Services.ArtDetailService();
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            string mdstr = artDetailServices.GetModel(id);
            ViewData["mdstr"] = mdstr;
            return View();
        }

        // 获取文章内容
        public IActionResult Art(int id)
        {
            Services.ArtDetailService artDetailServices = new Services.ArtDetailService();
            return Content(artDetailServices.GetModel(id));
        }

        // 文章列表（没用）
        public IActionResult ArtList()
        {
            Services.ArticleService artServices = new Services.ArticleService();
            return View(artServices.GetList());
        }

        // 文章列表（没用）
        public IActionResult ArtJsonList()
        {
            return Json("{}");
        }

        #endregion

        #region 后台管理

        // 后台管理列表页
        public IActionResult ArtManage()
        {
            int UserID = GetUserID();
            if (UserID <= 0)
            {
                return RedirectToAction("Index", "User");
            }
            Services.ArticleService artSer = new Services.ArticleService();

            return View(artSer.GetListByUserID(UserID));
        }

        // 编辑（编辑的逻辑:添加与编辑的页面相同，编辑的逻辑是直接打开编辑页，添加的逻辑是在弹出层中添加文章的名称和类型等，然后再打开编辑页）
        public IActionResult ArtEdit(int id)
        {
            //
            if (id == 0 || GetUserID() <= 0)
            {
                return RedirectToAction("Index", "User");
            }
            ArticleTypeService atSer = new ArticleTypeService();
            Services.ArticleService artSer = new Services.ArticleService();
            ViewData["arttype"] = atSer.GetList();
            var data = artSer.GetModelByID(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult ArtEdit(ArticleEditModel model)
        {
            //
            int userID = GetUserID();
            if (userID <= 0)
            {
                return RedirectToAction("Index", "User");
            }
            Services.ArticleService artSer = new Services.ArticleService();
            Services.ArtDetailService detSer = new Services.ArtDetailService();
            Models.ArtDetailModel detModel = new Models.ArtDetailModel();
            detModel.ArtID = model.ArtID;
            detModel.DetContent = model.DetContent;
            Models.ArticleModel artModel = new Models.ArticleModel();
            artModel.ArtID = model.ArtID;
            artModel.ArtTypeID = model.ArtTypeID;
            artModel.UserID = userID;
            artModel.ArtTitle = model.ArtTitle;
            artModel.ArtDetail = model.ArtDetail;
            artModel.EditTime = DateTime.Now;
            bool result = false;
            result = artSer.Update(artModel) ? true : false;

            result = (result && detSer.Update(detModel)) ? true : false;
            if (result)
            {
                return RedirectToAction("ArtManage", "Article");
            }
            else
            {
                return RedirectToAction("ArtEdit", "Article", artModel.ArtID);
            }
        }
        
        [HttpPost]
        public IActionResult Add(string artTitle,string artDetail,int artTypeID)
        {
            //
              int userID = GetUserID();
              int result = 0;
            if (userID <= 0)
            {
                return RedirectToAction("Index", "User");
            }
            Services.ArticleService artSer = new Services.ArticleService();
            Models.ArticleModel artModel = new Models.ArticleModel();
            artModel.ArtTypeID = artTypeID;
            artModel.UserID = userID;
            artModel.ArtTitle = artTitle;
            artModel.ArtDetail = artDetail;
            artModel.EditTime = DateTime.Now;
            artModel.AddTime = DateTime.Now;
            
            artModel.ArtID = artSer.Insert(artModel);
            if(artModel.ArtID>0){
                //
                Services.ArtDetailService detSer = new Services.ArtDetailService();
                Models.ArtDetailModel detModel = new Models.ArtDetailModel();
                detModel.ArtID = artModel.ArtID;
                detModel.DetContent = "MD 文档"; 
                int row = detSer.Insert(detModel);
                if(row>0)
                {
                    result = 1;
                }
            }

            return Content(result.ToString());
        }

        // 验证用户登录 返回0 未登录 返回>0用户ID
        private int GetUserID()
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
    }
}