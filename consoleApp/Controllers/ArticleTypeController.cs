using System;
using Microsoft.AspNetCore.Mvc;
using ConsoleApp.Models;
using ConsoleApp.Services;
using Newtonsoft.Json;

namespace ConsoleApp.Controllers
{
    public class ArticleTypeController : Controller
    {
        public IActionResult GetList(){
            ArticleTypeService atSer = new ArticleTypeService();
            var data = atSer.GetList();
            return Json(JsonConvert.SerializeObject(data));
        }
    }
}