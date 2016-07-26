using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ConsoleApp.Controllers
{
    public class UserController : Controller
    {
        //登录界面
        public IActionResult Index()
        {
            if (CheckLogin())
            {
                return RedirectToAction("ArtManage", "Article");
            }
            return View();
        }

        // 登录校验
        [HttpPost]
        public IActionResult Login(Models.LoginViewModel model)
        {
            if (String.IsNullOrWhiteSpace(model.UserName) || String.IsNullOrWhiteSpace(model.Password) || String.IsNullOrWhiteSpace(model.CheckCode))
            {
                return RedirectToAction("Index", "User");
            }
            if (!CheckCheckCode(model.CheckCode.ToUpper()))
            {
                return RedirectToAction("Index", "User");
            }
            Services.UserService userService = new Services.UserService();
            int UserId = userService.GetUserID(model.UserName, Services.SecurityHelper.Md5Encrypt32(model.Password));
            if (UserId <= 0)
            {
                return RedirectToAction("Index", "User");
            }

            HttpContext.Session.Set("User", System.Text.Encoding.UTF8.GetBytes(UserId.ToString()));
            return RedirectToAction("ArtManage", "Article");
        }

        // 获取验证码
        public IActionResult CheckCode()
        {
            //
            Services.ValidateCode vCode = new Services.ValidateCode();
            string code = vCode.CreateValidateCode(4);
            //HttpContext

            HttpContext.Session.Set("CheckCode", System.Text.Encoding.UTF8.GetBytes(code.ToUpper()));
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        // 用户列表
        public IActionResult UserList()
        {
            if (!CheckLogin())
            {
                return RedirectToAction("Index", "User");
            }
            Services.UserService userService = new Services.UserService();
            return View(userService.GetList());
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Article");
        }

        // 校验验证码
        public bool CheckCheckCode(string code)
        {
            byte[] ecode;
            HttpContext.Session.TryGetValue("CheckCode", out ecode);
            if (ecode != null || ecode.Length > 0)
            {
                string ecodeStr = System.Text.Encoding.UTF8.GetString(ecode);
                if (ecodeStr == code)
                    return true;
            }
            return false;
        }

        // 验证用户登录
        private bool CheckLogin()
        {
            try
            {
                //
                byte[] bts;
                HttpContext.Session.TryGetValue("User", out bts);
                if (bts != null && bts.Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // 注册界面
        public IActionResult Register()
        {
            return View();
        }

        // 注册响应
        public IActionResult UserRegister(Models.RegistViewModel model)
        {
            Services.UserService userService = new Services.UserService();
            model.Password = Services.SecurityHelper.Md5Encrypt32(model.Password);
            if (userService.GetMailCount(model.Mail) > 0)
            {
                // 邮件已经存在
                ViewData["ResultCode"] = 1;
            }
            else if (userService.GetUserNameCount(model.UserName) > 0)
            {
                // 邮件已经存在
                ViewData["ResultCode"] = 2;
            }
            else if (userService.Insert(model) > 0)
            {
                // 
                ViewData["ResultCode"] = 3;
            }
            ViewData["ResultCode"] = 0;

            return View();
        }

        // 验证邮箱是否存在
        public IActionResult CheckMail(string mail)
        {
            Services.UserService userService = new Services.UserService();
            return Content(userService.GetMailCount(mail) > 0 ? "1" : "0");
            //return Json("{}");
        }

        // 验证邮箱是否存在
        public IActionResult CheckUserName(string userName)
        {
            Services.UserService userService = new Services.UserService();
            return Content(userService.GetUserNameCount(userName) > 0 ? "1" : "0");
            //return Json("{}");
        }

        // 激活
        public IActionResult Activate(string code)
        {
            return View();
        }

    }

}