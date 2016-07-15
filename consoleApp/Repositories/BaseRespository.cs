using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp.Resopsitories{
    public class BaseRespository{ 
        protected string ConnStr = "Data Source=.;Initial Catalog=BBS;User ID=sa;Password=123.com;";
		#region dapper SqlServer封装方法
		protected T QuerySingle<T>(IDbConnection sqlConnection, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
		{
			using (sqlConnection)
			{
				var result = sqlConnection.Query<T>(sql, param, null, buffered, commandTimeout, commandType);
				if (result == null)
					return default(T);

				return result.FirstOrDefault();
			}
		}

		protected List<T> Query<T>(IDbConnection sqlConnection, string sql, object param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
		{
			using (sqlConnection)
			{
				var result = sqlConnection.Query<T>(sql, param, null, buffered, commandTimeout, commandType).ToList();

				return result;
			}
		}

		protected SqlConnection OpenMsSqlConnection()
		{
			SqlConnection connection = new SqlConnection(ConnStr);
			connection.Open();
			return connection;
		}
		#endregion
    }

    public class MySqlBaseRspository{
        #region dapper for mySql  
        /*
        protected MySqlConnection OpenMySqlConnection(){
            //
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=test;uid=root;pwd=;charset='gbk'");
            return con;
        }

        public void Execute(){
            //新增数据
            con.Execute("insert into user values(null, '测试', 'http://www.cnblogs.com/linezero/', 18)");
            //修改数据
            con.Execute("update user set UserName = 'linezero123' where Id = @Id", new { Id = id });
            //删除数据
            con.Execute("delete from user where Id = @Id", new { Id = id });
        }

        public T QuerySingle<T>(string sql, object param = null){

            return con.QueryFirst<T>(sqlStr);
            //新增数据返回自增id
            //var id=con.QueryFirst<int>("insert into user values(null, 'linezero', 'http://www.cnblogs.com/linezero/', 18);select last_insert_id();");
        }

        public List<T> QueryList<T>(string sql, object param = null){
            //
            var list=con.Query<T>(sql);
            return list;
        } 
        */
        #endregion 
    }
}