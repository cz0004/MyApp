using System;
using System.Collections.Generic;
using System.Text;
using MyAppModel.EFModel;
using MyAppService.Interfaces;
using MyAppBLL.IBLL;

namespace MyAppService.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoBLL _userInfoBLL;
        public UserInfoService(IUserInfoBLL userInfoBLL)
        {
            _userInfoBLL = userInfoBLL;
        }
        public UserInfo GetUserInfo(int ID)
        {
            return _userInfoBLL.GetInfo(ID);
        }

        public UserInfo GetUserInfo(string UserName)
        {
            throw new NotImplementedException();
        }
    }
}
