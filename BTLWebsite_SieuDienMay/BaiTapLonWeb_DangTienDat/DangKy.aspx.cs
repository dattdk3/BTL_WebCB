using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiTapLonWeb_VuHuyHoang
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["login"] == true)
            {
                Response.Redirect("TrangChu.aspx");
            }
            string path = "listMember.xml";
            if (Request.Form["btnSignUp"] == "true")
            {
                List<Member> members = new List<Member>();

                if (File.Exists(Server.MapPath(path)))
                {
                    // Đọc file
                    System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));
                    StreamReader file = new StreamReader(Server.MapPath(path));

                    members = (List<Member>)reader.Deserialize(file);
                    members = members.OrderBy(Member => Member.Id).ToList();//Sắp xếp dữ liệu theo ID
                    file.Close();
                }


                Member mb = new Member();
                mb.Id = members.Count;
                mb.NickName1 = Request.Form["username"];
                mb.Pass = Request.Form["pass"];

                bool checktrung = false;
                foreach (Member mem in members)
                {
                    if (mem.NickName1.Equals(mb.NickName1))
                    {
                        checktrung = true;
                        break;
                    }
                }

                if (!checktrung)
                {
                    foreach (Member mem in members)
                    {
                        if (mem.Id == mb.Id)
                        {
                            mb.Id++;
                        }
                    }
                    members.Add(mb);
                    //Ghi file
                    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));

                    System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path));

                    writer.Serialize(_file, members);
                    _file.Close();

                    // Tạo session
                    Session["login"] = true;
                    Session["id"] = mb.Id;
                    Session["TK"] = mb.NickName1;
                    Session["Pass"] = mb.Pass;

                    if ((bool)Session["login"] == true)
                    {
                        Response.Redirect("TrangChu.aspx");
                    }
                }
                else
                {
                    string alert = "";
                    alert += "<script>alert('Tài khoản đã tồn tại!');</script>";
                    Response.Write(alert);
                }

            }

        }
    }
}