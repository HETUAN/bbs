using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using ConsoleApp.Models;
using System.Text;

namespace ConsoleApp.Resopsitories
{
    public class ArticleRespository : BaseRespository
    {

        public List<ArticleViewModel> GetList(int sidx = 0, int eidx = 30)
        {
            //string sqlStr = "SELECT  `ArtID` ,  `ArtTitle` ,  `ArtDetail` ,  `UserID` ,  `AddTime` ,  `EditTime` ,  `ArticleState` ,  `ArtTypeID` FROM  `Article`  WHERE `ArticleIsDelete`= 0";
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT art.ArtID, art.ArtTitle, art.ArtDetail, us.UserName, art.AddTime, art.EditTime, art.ArticleState, at.ArtTypeName");
            sqlStr.AppendLine("FROM Article art");
            sqlStr.AppendLine("LEFT JOIN ArtType at ON art.ArtTypeID = at.ArtTypeID");
            sqlStr.AppendLine("LEFT JOIN Users us ON us.UserID = art.UserID");
            sqlStr.AppendLine("WHERE ArticleIsDelete =0");
            sqlStr.AppendLine("ORDER BY art.EditTime DESC");
            sqlStr.AppendLine("LIMIT " + sidx + " , " + eidx + "");

            return base.Query<ArticleViewModel>(OpenSqlConnection(), sqlStr.ToString());
        }

        public List<ArticleViewModel> GetListByUserID(int userID, int sidx = 0, int eidx = 30)
        {
            //string sqlStr = "SELECT  `ArtID` ,  `ArtTitle` ,  `ArtDetail` ,  `UserID` ,  `AddTime` ,  `EditTime` ,  `ArticleState` ,  `ArtTypeID` FROM  `Article`  WHERE `ArticleIsDelete`= 0";
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT art.ArtID, art.ArtTitle, art.ArtDetail, us.UserName, art.AddTime, art.EditTime, art.ArticleState, at.ArtTypeName");
            sqlStr.AppendLine("FROM Article art");
            sqlStr.AppendLine("LEFT JOIN ArtType at ON art.ArtTypeID = at.ArtTypeID");
            sqlStr.AppendLine("LEFT JOIN Users us ON us.UserID = art.UserID");
            sqlStr.AppendLine("WHERE ArticleIsDelete =0 AND art.UserID ="+userID+" ");
            sqlStr.AppendLine("ORDER BY art.EditTime DESC");
            sqlStr.AppendLine("LIMIT " + sidx + " , " + eidx + "");

            return base.Query<ArticleViewModel>(OpenSqlConnection(), sqlStr.ToString());
        }
        
        public ArticleViewModel GetModelByID(int artID)
        {
            //string sqlStr = "SELECT  `ArtID` ,  `ArtTitle` ,  `ArtDetail` ,  `UserID` ,  `AddTime` ,  `EditTime` ,  `ArticleState` ,  `ArtTypeID` FROM  `Article`  WHERE `ArticleIsDelete`= 0";
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT art.ArtID, art.ArtTitle, art.ArtDetail, us.UserID, art.AddTime, art.EditTime, art.ArticleState, at.ArtTypeID");
            sqlStr.AppendLine("FROM Article art");
            sqlStr.AppendLine("LEFT JOIN ArtType at ON art.ArtTypeID = at.ArtTypeID");
            sqlStr.AppendLine("LEFT JOIN Users us ON us.UserID  = art.UserID");
            sqlStr.AppendLine("WHERE ArticleIsDelete =0 AND art.ArtID = "+artID+" ");
            //sqlStr.AppendLine("ORDER BY art.EditTime DESC");
            //sqlStr.AppendLine("LIMIT " + sidx + " , " + eidx + "");

            return base.QuerySingle<ArticleViewModel>(OpenSqlConnection(), sqlStr.ToString());
        }
    }
}