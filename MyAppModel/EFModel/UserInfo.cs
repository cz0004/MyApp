using System;
using System.Collections.Generic;

namespace MyAppModel.EFModel
{
    public partial class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserAvatar { get; set; }
    }
}
