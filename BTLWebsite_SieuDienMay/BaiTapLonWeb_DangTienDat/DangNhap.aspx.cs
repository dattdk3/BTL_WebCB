using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiTapLonWeb_VuHuyHoang
{
    public partial class DangNhap : System.Web.UI.Page
    {
        private static string privious = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack) privious = Request.UrlReferrer != null ? Request.UrlReferrer.ToString() : null;

            if ((bool)Session["login"] == true)
            {
                Response.Redirect("TrangChu.aspx");
            }
        }

        protected void btn_For_login(object sender, EventArgs e)
        {
            string path = "listMember.xml";
            if (Request.Form["btnlogin"] == "true")
            {
                List<Member> list = new List<Member>();

                if (File.Exists(Server.MapPath(path)))
                {
                    // Đọc file
                    System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));
                    StreamReader file = new StreamReader(Server.MapPath(path));

                    list = (List<Member>)reader.Deserialize(file);
                    list = list.OrderBy(Member => Member.Id).ToList();
                    file.Close();
                }

                Member mb = new Member();
                mb.Id = list.Count;
                mb.NickName1 = Request.Form["usn"];

                mb.Pass = Request.Form["password"];

                bool checktrung = false;
                foreach (Member mem in list)
                {
                    if (mem.NickName1.Equals(mb.NickName1) && mem.Pass.Equals(mb.Pass))
                    {
                        checktrung = true;
                        mb.Id = mem.Id;
                        break;
                    }
                }

                if (checktrung == false)
                {
                    string alert = "";
                    alert += "<script>alert('Tài khoản hoặc mật khẩu không đúng!');</script>";
                    Response.Write(alert);
                }
                else
                {
                    // Tạo session
                    Session["login"] = true;
                    Session["id"] = mb.Id;
                    Session["TK"] = mb.NickName1;
                    Session["Pass"] = mb.Pass;
                }

                if ((bool)Session["login"] == true)
                {
                    Response.Redirect(privious != null ? privious : "TrangChu.aspx");
                }
            }
        }
    }
}