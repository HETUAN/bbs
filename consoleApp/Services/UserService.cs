using System;
using ConsoleApp.Models;
using System.Collections.Generic;

namespace ConsoleApp.Services{
    public class UserService{
        Resopsitories.UserRespository userRespository = new Resopsitories.UserRespository();

        public string UserLogin(LoginViewModel model){
            //
            return "success";
        }
        
        public int GetUserCount(){
            return userRespository.GetUserCount();
        }
        
        public List<UserViewModel> GetList(){
            return userRespository.GetList();
        }

        public int GetUserID(string UserName,string Password)
        {
            return userRespository.GetUserID( UserName, Password);
        }
        
        public int GetMailCount(string mail){
            return userRespository.GetMailCount(mail);
        }

        public int GetUserNameCount(string userName){
            return userRespository.GetUserNameCount(userName);
        }
        
        public int Insert(RegistViewModel model){
            return userRespository.Insert(model);
        }
    }
}