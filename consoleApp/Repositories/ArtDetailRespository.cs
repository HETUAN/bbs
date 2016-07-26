using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using ConsoleApp.Models;
using System.Text;

namespace ConsoleApp.Resopsitories
{
    public class ArtDetailRespository : BaseRespository
    {
        #region  MsSql���ݿ�����

        /*
        public int Insert(ArtDetailModel model){
            //
            var strSqlRef = new StringBuilder();
            strSqlRef.Append("INSERT INTO [ArtDetail]");
            strSqlRef.Append("    ([DetContent]");
            strSqlRef.Append("    ,[ArtID])");
            strSqlRef.Append("VALUES");
            strSqlRef.Append("    (@DetContent");
            strSqlRef.Append("    ,@ArtID)");
            SqlParameter[] parametersRef = {
					new SqlParameter("@DetContent", SqlDbType.Text,4),
					new SqlParameter("@ArtID", SqlDbType.Int,4)};
            parametersRef[0].Value = model.DetContent;
            parametersRef[1].Value = model.ArtID; 

            int result = base.ExecuteNonQuery(base.OpenSqlConnection(), strSqlRef.ToString(), parametersRef);
            return result;
        }
        
        
        /// <summary>
        /// Ʒ������Ʒ�ƵĹ�����
        /// </summary>
        /// <param name="bsid">��Ʒ��ID</param>
        /// <param name="cbid">Ʒ��ID</param>
        /// <param name="status">����״̬</param>
        public bool Update(ArtDetailModel model)
        { 
            var strSqlRef = new StringBuilder();
            strSqlRef.Append("UPDATE [ArtDetail]");
            strSqlRef.Append("    SET [DetContent] = @DetContent");
            strSqlRef.Append("WHERE [ArtID] = @ArtID"); 
            SqlParameter[] parametersRef = {
                                               new SqlParameter("@DetContent", SqlDbType.Text, 4),
                                               new SqlParameter("@ArtID", SqlDbType.Int, 4)
                                           };
            parametersRef[0].Value = model.DetContent;
            parametersRef[1].Value = model.ArtID;
            
            bool result = base.ExecuteNonQuery(base.OpenSqlConnection(), strSqlRef.ToString(), parametersRef) > 0;
            return result;
        }
        */
        #endregion
        public int Insert(ArtDetailModel model)
        {
            //
            var strSqlRef = new StringBuilder();
            strSqlRef.Append("INSERT INTO ArtDetail");
            strSqlRef.Append("    (DetContent");
            strSqlRef.Append("    ,ArtID) ");
            strSqlRef.Append("VALUES");
            strSqlRef.Append("    (@DetContent");
            strSqlRef.Append("    ,@ArtID)"); 

            int result = base.ExecuteNonQuery(base.OpenSqlConnection(), strSqlRef.ToString(), new {model.DetContent, model.ArtID});
            return result;
        }


        /// <summary>
        /// 品牌与主品牌的关联表
        /// </summary>
        /// <param name="bsid">主品牌ID</param>
        /// <param name="cbid">品牌ID</param>
        /// <param name="status">数据状态</param>
        public bool Update(ArtDetailModel model)
        {
            /*
            try
            {}
            catch (System.Exception ex)
            {
                return false;
                throw;
            }
              */
            var strSqlRef = new StringBuilder();
            strSqlRef.Append("UPDATE ArtDetail");
            strSqlRef.Append("    SET  DetContent = @DetContent ");
            strSqlRef.Append("WHERE ArtID = @ArtID");
        
            bool result = base.ExecuteNonQuery(base.OpenSqlConnection(), strSqlRef.ToString(), new { model.DetContent, model.ArtID }) > 0;
            return result;
        }


        public string GetModel(int ArtId)
        {
            return base.QuerySingle<string>(OpenSqlConnection(), "SELECT  `DetContent` FROM  `ArtDetail` WHERE`ArtID` = @ArtID", new { ArtId });
        }

        public bool CheckExist(int artID)
        {
            string sqlStr = "SELECT COUNT(1) FROM ArtDetail WHERE ArtID = @ArtID";
            int row = base.QuerySingle<int>(base.OpenSqlConnection(), sqlStr, new { artID });
            return row > 0;
        }

    }
}