using System;

namespace ConsoleApp.Models
{
    public class  UserViewModel{
        public int UserID{get;set;}

        public string UserName{get;set;}

        public string UserHead{get;set;}

        public string Mail{get;set;}

        public int Sex{get;set;}
    }

    public class RegistViewModel{
        
        public string UserName{get;set;}

        public string Password{get;set;}

        public string Mail{get;set;}
    }
    
    public class LoginViewModel{
        public string UserName{get;set;}

        public string Password{get;set;}

        public string CheckCode{get;set;}
    }

    public class  UserModel{
        public int UserID{get;set;}
        
        /// <summary>
        /// 用户名
        /// </summary>
        /// <returns></returns>
        public string UserName{get;set;}

        /// <summary>
        /// 权限
        /// </summary>
        /// <returns></returns>
        public string UserPowerID{get;set;}

        /// <summary>
        /// 头像
        /// </summary>
        /// <returns></returns>
        public string UserHead{get;set;}

        /// <summary>
        /// 状态 0-未激活 1-已激活
        /// </summary>
        /// <returns></returns>
        public int UserState{get;set;}

        /// <summary>
        /// 地址
        /// </summary>
        /// <returns></returns>
        public string Address{get;set;}

        /// <summary>
        /// 性别 0-保密 1-男 2-女
        /// </summary>
        /// <returns></returns>
        public int Sex{get;set;}

        /// <summary>
        /// 真实姓名
        /// </summary>
        /// <returns></returns>
        public string RealName{get;set;}

        /// <summary>
        /// 电话
        /// </summary>
        /// <returns></returns>
        public string Phone{get;set;}

        /// <summary>
        /// 邮箱
        /// </summary>
        /// <returns></returns>
        public string Mail{get;set;}

        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateTime{get;set;}

        /// <summary>
        /// 最近修改时间
        /// </summary>
        /// <returns></returns>
        public DateTime? EditTime{get;set;}

        /// <summary>
        /// 是否删除 0-未删除 1-已删除
        /// </summary>
        /// <returns></returns>
        public int IsDelete{get;set;}
    }
}