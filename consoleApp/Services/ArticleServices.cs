using System;
using ConsoleApp.Models;
using System.Collections.Generic;

namespace ConsoleApp.Services{
    public class ArticleService{
        Resopsitories.ArticleRespository artRespository = new Resopsitories.ArticleRespository();
        public List<ArticleViewModel> GetList(){
            //
            return artRespository.GetList();
        }
    }
}