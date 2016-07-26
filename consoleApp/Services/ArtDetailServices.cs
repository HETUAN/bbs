using System;
using ConsoleApp.Models;
using System.Collections.Generic;

namespace ConsoleApp.Services{
    public class ArtDetailService{
        Resopsitories.ArtDetailRespository artDetailRespository = new Resopsitories.ArtDetailRespository();
        
        public int Insert(ArtDetailModel model){
            return artDetailRespository.Insert(model);
        }
        
        public bool Update(ArtDetailModel model){
            
            if (artDetailRespository.CheckExist(model.ArtID))
            {
                return artDetailRespository.Update(model);
            }
            else
            {
                return artDetailRespository.Insert(model) > 0;
            } 
        }
        
        public string GetModel(int ArtId)
        {
            return artDetailRespository.GetModel(ArtId);
        }
    }
}