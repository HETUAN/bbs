using System;
using Microsoft.AspNetCore.Mvc;
using ConsoleApp.Models;
using ConsoleApp.Services;
using Newtonsoft.Json;

namespace ConsoleApp.Controllers
{
    public class ArticleTypeController : Controller
    {
        public IActionResult GetList()
        {
            ArticleTypeService atSer = new ArticleTypeService();
            var data = atSer.GetList();
            return Json(JsonConvert.SerializeObject(data));
        }

        public IActionResult Index()
        {
            int userID = GetUserID();
            if (userID <= 0)
            {
                return RedirectToAction("Index", "User");
            }

            ArticleTypeService atSer = new ArticleTypeService();
            var data = atSer.GetList();
            return View(data);
        }

        public IActionResult Edit(int id = 0)
        {
            ViewData["errmsg"] = "";
            int userID = GetUserID();
            if (userID <= 0)
            {
                return RedirectToAction("Index", "User");
            }
            if (id > 0)
            {
                //return RedirectToAction("Index", "ArticleType");
                ArticleTypeService atSer = new ArticleTypeService();
                var data = atSer.GetModel(id);
                return View(data);
            }
            else
            {
                var data = new Models.ArticleType();
                return View(data);
            }
        }

        [HttpPost]
        public IActionResult Edit(int ArtTypeId, string ArtTypeName)
        {
            ViewData["errmsg"] = "";
            ArticleType model = new ArticleType();
            model.ArtTypeID = ArtTypeId;
            model.ArtTypeName = ArtTypeName;
            ArticleTypeService atSer = new ArticleTypeService();
            if (ArtTypeId == 0)
            {
                if(atSer.CheckExist(ArtTypeName)>0)
                {
                    ViewData["errmsg"] = "名称已经存在";
                    return View(model);
                }
                if (atSer.Insert(model) > 0)
                {
                    return RedirectToAction("Index", "ArticleType");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                if (atSer.Update(model))
                {
                    return RedirectToAction("Index", "ArticleType");
                }
                else
                {
                    return View(model);
                }
            }
        }

        /// <summary>
        /// 检查名称是否存在
        /// </summary>
        /// <param name="ArtTypeName"></param>
        /// <returns></returns>
        public IActionResult CheckExist(string ArtTypeName)
        {
            //
            if (string.IsNullOrWhiteSpace(ArtTypeName))
            {
                //
                return Content("1");
            }
            else
            {
                ArticleTypeService atSer = new ArticleTypeService();
                if (atSer.CheckExist(ArtTypeName) > 0)
                {
                    return Content("1");
                }
                else
                {
                    return Content("0");
                }
            }
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

    }
}