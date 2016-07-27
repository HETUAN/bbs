using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ConsoleApp.Resopsitories
{
    public class MsSqlBaseRespository
    {
        protected string ConnStr = "Data Source=.;Initial Catalog=BBS;User ID=sa;Password=123.com;";
        #region dapper SqlServer封装方法


        public int ExecuteNonQuery(IDbConnection sqlConnection, string sql, object param = null)
        {
            return sqlConnection.Execute(sql, param);
        }

        protected T QuerySingle<T>(IDbConnection sqlConnection, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = CommandType.Text)
        {
            using (sqlConnection)
            {
                var result = sqlConnection.Query<T>(sql, param, null, buffered, commandTimeout, commandType);
                if (result == null)
                    return default(T);

                return result.FirstOrDefault();
            }
        }

        protected List<T> Query<T>(IDbConnection sqlConnection, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = CommandType.Text)
        {
            using (sqlConnection)
            {
                var result = sqlConnection.Query<T>(sql, param, null, buffered, commandTimeout, commandType).ToList();

                return result;
            }
        }

        protected SqlConnection OpenSqlConnection()
        {
            SqlConnection connection = new SqlConnection(ConnStr);
            connection.Open();
            return connection;
        }
        #endregion
    }

    public class BaseRespository
    { 
        //protected string ConnStr = "server=52.197.53.214;database=bbs;uid=bruce;pwd=bruce@*#%;charset='utf8'";
        protected string ConnStr = "server=localhost;database=bbs;uid=root;pwd=tuanzhang1925;charset='utf8'";
        protected MySqlConnection OpenSqlConnection()
        {
            // 
            MySqlConnection connection = new MySqlConnection(ConnStr);
            connection.Open();
            return connection;
        }

        protected int ExecuteNonQuery(MySqlConnection con, string sql, object param = null)
        {
            try
            {
                //修改数据
                int row = con.Execute(sql, param);
                return row;
            }
            catch (System.Exception ex)
            {
                return 0;
            }
        }

        protected T QuerySingle<T>(MySqlConnection con, string sql, object param = null)
        {
            try
            {
            return con.QueryFirst<T>(sql, param);
            }
            catch (System.Exception ex)
            {
                return default(T);
            }
        }

        protected List<T> Query<T>(MySqlConnection con, string sql, object param = null)
        {
            //
            try
            {
                return con.Query<T>(sql, param).ToList();
            }
            catch (System.Exception ex)
            {
                return null;
            }
        } 
    }
}