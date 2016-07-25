using System;
using ConsoleApp.Models;
using System.Collections.Generic;

namespace ConsoleApp.Services
{
    public class ArticleTypeService
    {
        Resopsitories.ArticleTypeRespository artTypeRes = new Resopsitories.ArticleTypeRespository();
        public List<ArticleType> GetList()
        {
            return artTypeRes.GetList();
        }
    }
}