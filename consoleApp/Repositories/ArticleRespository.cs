using System;
using System.Data.SqlClient; 
using System.Data;
using System.Collections.Generic;
using ConsoleApp.Models;
using System.Text;

namespace ConsoleApp.Resopsitories{
    public class ArticleRespository:BaseRespository{
        
        public List<ArticleViewModel> GetList()
        {
            return base.Query<ArticleViewModel>(OpenSqlConnection(), "SELECT  `ArtID` ,  `ArtTitle` ,  `ArtDetail` ,  `UserID` ,  `AddTime` ,  `EditTime` ,  `ArticleState` ,  `ArtTypeID` FROM  `Article`  WHERE `ArticleIsDelete`= 0");
        }
        
    }
}