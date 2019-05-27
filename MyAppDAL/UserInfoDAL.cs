using System;
using System.Collections.Generic;
using System.Text;
using MyAppModel.EFModel;
using System.Linq;
using MyAppDAL.IDAL;

namespace MyAppDAL
{
    public class UserInfoDAL:BaseDAL<UserInfo>, IUserInfoDAL
    {
    }
}
