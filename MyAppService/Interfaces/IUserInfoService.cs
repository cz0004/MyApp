using System;
using System.Collections.Generic;
using System.Text;
using MyAppModel.EFModel;

namespace MyAppService.Interfaces
{
    public interface IUserInfoService
    {
        UserInfo GetUserInfo(int ID);
        UserInfo GetUserInfo(string UserName);
    }
}
