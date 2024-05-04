using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTapLonWeb_VuHuyHoang
{
    public class Member
    {
        string NickName;
        int id;
        string pass;

        public string NickName1 { get => NickName; set => NickName = value; }
        public int Id { get => id; set => id = value; }
        public string Pass { get => pass; set => pass = value; }
    }
}