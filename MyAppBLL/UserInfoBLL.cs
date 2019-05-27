using System;
using System.Collections.Generic;
using System.Text;
using MyAppBLL.IBLL;
using MyAppDAL;
using MyAppDAL.IDAL;
using MyAppModel.EFModel;
namespace MyAppBLL
{
    public class UserInfoBLL : BaseBLL<UserInfo>, IUserInfoBLL
    {
        private UserInfoDAL _userInfoDAL;
        public UserInfoBLL()
        {
            _userInfoDAL = new UserInfoDAL();
        }
        public override IBaseDAL<UserInfo> Dal => new BaseDAL<UserInfo>();
    }
}
