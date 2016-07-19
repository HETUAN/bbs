using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Text;

namespace ConsoleApp.Resopsitories
{
    public class MySqlHelper
    {
        public void test(){
             MySqlConnection con = new MySqlConnection("server=127.0.0.1;database=test;uid=root;pwd=;charset='gbk'");
            //新增数据
            con.Execute("insert into user values(null, '测试', 'http://www.cnblogs.com/linezero/', 18)");
            //新增数据返回自增id
            var id=con.QueryFirst<int>("insert into user values(null, 'linezero', 'http://www.cnblogs.com/linezero/', 18);select last_insert_id();");
            //修改数据
            con.Execute("update user set UserName = 'linezero123' where Id = @Id", new { Id = id.ToString() });
            //查询数据
            var list=con.Query<int>("select * from user");
            
            //删除数据
            con.Execute("delete from user where Id = @Id", new { Id = id.ToString() });
            Console.WriteLine("删除数据后的结果");
            list = con.Query<int>("select * from user");
        }
    }
}