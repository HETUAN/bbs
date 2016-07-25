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
            sqlStr.AppendLine("WHERE ArticleIsDelete =0 AND art.UserID =" + userID + " ");
            sqlStr.AppendLine("ORDER BY art.EditTime DESC");
            sqlStr.AppendLine("LIMIT " + sidx + " , " + eidx + "");

            return base.Query<ArticleViewModel>(OpenSqlConnection(), sqlStr.ToString());
        }

        public ArticleModel GetModelByID(int artID)
        {
            string sqlStr = "SELECT  `ArtID` ,  `ArtTitle` ,  `ArtDetail` ,  `UserID` ,  `AddTime` ,  `EditTime` ,  `ArticleState` , `ArticleIsDelete` ,  `ArtTypeID` FROM  `Article`  WHERE `ArticleIsDelete`= 0 AND ArtID = " + artID + " ";
            //StringBuilder sqlStr = new StringBuilder();
            //sqlStr.AppendLine("SELECT art.ArtID, art.ArtTitle, art.ArtDetail, us.UserID, art.AddTime, art.EditTime, art.ArticleState, at.ArtTypeID");
            //sqlStr.AppendLine("FROM Article art");
            //sqlStr.AppendLine("LEFT JOIN ArtType at ON art.ArtTypeID = at.ArtTypeID");
            //sqlStr.AppendLine("LEFT JOIN Users us ON us.UserID  = art.UserID");
            //sqlStr.AppendLine("WHERE ArticleIsDelete =0 AND art.ArtID = "+artID+" "); 

            return base.QuerySingle<ArticleModel>(OpenSqlConnection(), sqlStr.ToString());
        }

        public bool Update(Models.ArticleModel model)
        {
            StringBuilder sqlStr = new StringBuilder();
            //sqlStr.AppendLine("");
            sqlStr.AppendLine("UPDATE Article");
            sqlStr.AppendLine("    SET ArtTitle = @ArtTitle");
            sqlStr.AppendLine("        ,ArtDetail = @ArtDetail");
            sqlStr.AppendLine("        ,EditTime = @EditTime");
            sqlStr.AppendLine("        ,ArtTypeID = @ArtTypeID ");
            sqlStr.AppendLine("        WHERE ArtID = @ArtID");
            int row = base.ExecuteNonQuery(base.OpenSqlConnection(), sqlStr.ToString(), new { model.ArtTitle, model.ArtDetail, model.EditTime, model.ArtTypeID, model.ArtID });
            return row > 0;
        }

        public bool Delete(int artID)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("UPDATE Article");
            sqlStr.AppendLine("    SET ArticleIsDelete = 1");
            sqlStr.AppendLine("        WHERE ArtID = @ArtID");
            int row = base.ExecuteNonQuery(base.OpenSqlConnection(), sqlStr.ToString(), new { artID });
            return row > 0;
        }

        public int Insert(Models.ArticleModel model)
        {
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("INSERT INTO Article (ArtTitle, ArtDetail, UserID, AddTime, EditTime, ArticleState, ArticleIsDelete, ArtTypeID)");
            sqlStr.AppendLine("VALUES (@ArtTitle, @ArtDetail, @UserID, @AddTime, @EditTime, '1', '0', @ArtTypeID);");
            sqlStr.AppendLine("SELECT LAST_INSERT_ID();");
            int id = base.QuerySingle<int>(base.OpenSqlConnection(), sqlStr.ToString(), new { model.ArtTitle, model.ArtDetail, model.UserID, model.AddTime, model.EditTime, model.ArtTypeID });
            return id;
        }
    }
}