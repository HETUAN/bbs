using System;

namespace ConsoleApp.Models
{
    public class  ArticleModel{
        public int ArtID{get;set;}
        public string ArtTitle{get;set;}
        public string ArtDetail{get;set;}
        public int UserID{get;set;}
        public DateTime AddTime{get;set;}
        public DateTime EditTime{get;set;}
        public int ArticlesState{get;set;}
        public int ArticlesIsDelete{get;set;}
        public int ArtTypeID{get;set;}
    }
    
    public class  ArticleViewModel{
        public int ArtID{get;set;}
        public string ArtTitle{get;set;}
        public string ArtDetail{get;set;}
        //public int UserID{get;set;}
        public string UserName{get;set;}
        public DateTime AddTime{get;set;}
        public DateTime EditTime{get;set;}
        public int ArticlesState{get;set;} 
        //public int ArtTypeID{get;set;}
        public string ArtTypeName{get;set;}
    }
}