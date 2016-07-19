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
            return artDetailRespository.Update(model);
        }
        
        public string GetModel(int ArtId)
        {
            return artDetailRespository.GetModel(ArtId);
        }
    }
}