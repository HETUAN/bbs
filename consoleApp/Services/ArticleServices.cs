using System;
using ConsoleApp.Models;
using System.Collections.Generic;

namespace ConsoleApp.Services
{
    public class ArticleService
    {
        Resopsitories.ArticleRespository artRespository = new Resopsitories.ArticleRespository();
        public List<ArticleViewModel> GetList(int sidx = 0, int eidx = 30)
        {
            //
            return artRespository.GetList(sidx, eidx);
        }

        public List<ArticleViewModel> GetListByUserID(int userID, int sidx = 0, int eidx = 30)
        {
            return artRespository.GetListByUserID(userID, sidx, eidx);
        }

        public ArticleModel GetModelByID(int artID)
        {
            return artRespository.GetModelByID(artID);
        }

        public bool Update(Models.ArticleModel model)
        {
            return artRespository.Update(model);
        }


        public bool Delete(int artID)
        {
            return artRespository.Delete(artID);
        }

        public int Insert(Models.ArticleModel model)
        {
            return artRespository.Insert(model);
        }
    }
}