using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using ConsoleApp.Models;
using System.Text;

namespace ConsoleApp.Resopsitories
{
    public class ArticleTypeRespository : BaseRespository
    {
        public List<ArticleType> GetList()
        {
            string sqlStr = "SELECT ArtTypeID, ArtTypeName, ArtTypeState, ArtTypeIsDelete FROM ArtType WHERE ArtTypeIsDelete = 0";
            return base.Query<ArticleType>(base.OpenSqlConnection(), sqlStr);
        }

        public int Insert(ArticleType model)
        {
            //
            string sqlStr = "INSERT INTO ArtType (ArtTypeName, ArtTypeState, ArtTypeIsDelete) VALUES (@ArtTypeName, 1, 0); SELECT LAST_INSERT_ID();";
            return base.QuerySingle<int>(base.OpenSqlConnection(), sqlStr, new { model.ArtTypeName });
        }

        public bool Update(ArticleType model){
            string sqlStr = "UPDATE ArtType SET ArtTypeName = @ArtTypeName WHERE ArtTypeID = @ArtTypeID";
            return base.ExecuteNonQuery(base.OpenSqlConnection(), sqlStr, new { model.ArtTypeName,model.ArtTypeID })>0;
        }
        public ArticleType GetModel(int Id){
            string sqlStr = "SELECT ArtTypeID, ArtTypeName, ArtTypeState, ArtTypeIsDelete FROM ArtType WHERE ArtTypeID = @Id";
            return base.QuerySingle<ArticleType>(base.OpenSqlConnection(), sqlStr, new { Id });
        }

        public int CheckExist(string ArtTypeName){
            string sqlStr = "SELECT COUNT(1) FROM ArtType WHERE ArtTypeName = @ArtTypeName AND ArtTypeIsDelete = 0";
            return base.QuerySingle<int>(base.OpenSqlConnection(), sqlStr, new { ArtTypeName });
        }
    }
}