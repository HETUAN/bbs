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
        
        public int Insert(ArticleType model)
        {
            return artTypeRes.Insert(model);
        }

        public bool Update(ArticleType model){
            return artTypeRes.Update(model);
        }
        
        public ArticleType GetModel(int Id){
            return artTypeRes.GetModel(Id);
        }
        
        public int CheckExist(string ArtTypeName){
            return artTypeRes.CheckExist(ArtTypeName);
        }
    }
}