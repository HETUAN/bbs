using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography; 
using System.Text;

namespace ConsoleApp.Services
{
    public class SecurityHelper
    { 
        /// <summary>
        /// MD5加密16
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns></returns>
        /*
        public static string Md5Encrypt16(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            var data = Encoding.UTF8.GetBytes(input);
            var encs = md5.ComputeHash(data);
            return BitConverter.ToString(encs).Replace("-", "");
        }
        */

        /// <summary>
        /// MD5加密32
        /// </summary>
        /// <param name="input">输入</param>
        /// <returns></returns>
        public static string Md5Encrypt32(string str)
        {
            string cl = str;
            string pwd = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;
        }
    }
}