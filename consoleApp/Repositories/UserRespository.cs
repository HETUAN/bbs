using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using ConsoleApp.Models;
using System.Text;

namespace ConsoleApp.Resopsitories
{
    public class UserRespository : BaseRespository
    {
        #region MsSql 数据库操作
        /*
        public int GetUserCount()
        {
            int num = base.ExecuteNonQuery(base.OpenSqlConnection(), "SELECT COUNT(1) FROM Users", null);
            return num;
        }

        public List<UserViewModel> GetList()
        {
            return base.Query<UserViewModel>(OpenSqlConnection(), "SELECT UserID,UserName,UserHead,Mail,Sex FROM Users");
        }


        public int GetUserID(string UserName, string Password)
        {
            return base.QuerySingle<int>(OpenSqlConnection(), "SELECT [UserID] FROM [Users] WHERE [UserName] = @UserName AND [Password] = @Password", new { UserName, Password });
        }

        public int GetMailCount(string mail)
        {

            SqlParameter[] parametersRef = {
                    new SqlParameter("@Mail", SqlDbType.NVarChar)};
            parametersRef[0].Value = mail;
            int num = base.ExecuteNonQuery(base.OpenSqlConnection(), "SELECT COUNT(1) FROM Users WHERE IsDelete = 0 AND Mail = @Mail", parametersRef);
            return num;
        }

        public int GetUserNameCount(string userName)
        {
            SqlParameter[] parametersRef = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar)};
            parametersRef[0].Value = userName;
            int num = base.ExecuteNonQuery(base.OpenSqlConnection(), "SELECT COUNT(1) FROM Users WHERE IsDelete = 0 AND UserName = @UserName", parametersRef);
            return num;
        }

        public int Insert(RegistViewModel model)
        {
            //
            var strSqlRef = new StringBuilder();
            strSqlRef.Append("INSERT INTO [Users]([UserName],[Password],[Mail])");
            strSqlRef.Append("    VALUES");
            strSqlRef.Append("        (@UserName,@Password, @Mail);SELECT @@IDENTITY");
            SqlParameter[] parametersRef = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,4),
                    new SqlParameter("@Password", SqlDbType.NVarChar,4),
                    new SqlParameter("@Mail", SqlDbType.NVarChar,4)};
            parametersRef[0].Value = model.UserName;
            parametersRef[1].Value = model.Password;
            parametersRef[2].Value = model.Mail;

            int result = base.ExecuteNonQuery(base.OpenSqlConnection(), strSqlRef.ToString(), parametersRef);
            return result;
        }
        */
        #endregion 
        
        #region MySql 数据库操作
        public int GetUserCount()
        {
            int num = base.ExecuteNonQuery(base.OpenSqlConnection(), "SELECT COUNT(1) FROM Users", null);
            return num;
        }

        public List<UserViewModel> GetList()
        {
            return base.Query<UserViewModel>(OpenSqlConnection(), "SELECT UserID,UserName,UserHead,Mail,Sex FROM Users");
        }


        public int GetUserID(string UserName, string Password)
        {
            return base.QuerySingle<int>(OpenSqlConnection(), "SELECT UserID FROM Users WHERE UserName = @UserName AND Password = @Password", new { UserName, Password });
        }

        public int GetMailCount(string mail)
        {

            SqlParameter[] parametersRef = {
                    new SqlParameter("@Mail", SqlDbType.NVarChar)};
            parametersRef[0].Value = mail;
            int num = base.ExecuteNonQuery(base.OpenSqlConnection(), "SELECT COUNT(1) FROM Users WHERE IsDelete = 0 AND Mail = @Mail", parametersRef);
            return num;
        }

        public int GetUserNameCount(string userName)
        {
            SqlParameter[] parametersRef = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar)};
            parametersRef[0].Value = userName;
            int num = base.ExecuteNonQuery(base.OpenSqlConnection(), "SELECT COUNT(1) FROM Users WHERE IsDelete = 0 AND UserName = @UserName", parametersRef);
            return num;
        }

        public int Insert(RegistViewModel model)
        {
            //
            var strSqlRef = new StringBuilder();
            strSqlRef.Append("INSERT INTO Users(UserName,Password,Mail)");
            strSqlRef.Append("    VALUES");
            strSqlRef.Append("        (@UserName,@Password, @Mail);SELECT @@IDENTITY");
            SqlParameter[] parametersRef = {
                    new SqlParameter("@UserName", SqlDbType.NVarChar,4),
                    new SqlParameter("@Password", SqlDbType.NVarChar,4),
                    new SqlParameter("@Mail", SqlDbType.NVarChar,4)};
            parametersRef[0].Value = model.UserName;
            parametersRef[1].Value = model.Password;
            parametersRef[2].Value = model.Mail;

            int result = base.ExecuteNonQuery(base.OpenSqlConnection(), strSqlRef.ToString(), parametersRef);
            return result;
        }
        
        #endregion 
    }
}