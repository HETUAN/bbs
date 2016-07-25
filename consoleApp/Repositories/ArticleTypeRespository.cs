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
            string sqlStr = "SELECT ArtTypeID, ArtTypeName, ArtTypeState, ArtTypeIsDelete FROM ArtType";
            return base.Query<ArticleType>(base.OpenSqlConnection(), sqlStr);
        }
    }
}