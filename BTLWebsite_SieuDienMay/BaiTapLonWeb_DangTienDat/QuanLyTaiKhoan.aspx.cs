using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiTapLonWeb_VuHuyHoang
{
    public partial class QuanLyTaiKhoan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["TK"] != "admin" || (bool)Session["login"] == false)
            {
                Response.Redirect("TrangChu.aspx");
            }
            string path = "listMember.xml";

            List<Member> list = new List<Member>();
            if (File.Exists(Server.MapPath(path)))
            {
                // Đọc file
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));
                StreamReader file = new StreamReader(Server.MapPath(path));

                list = (List<Member>)reader.Deserialize(file);
                list = list.OrderByDescending(Member => Member.Id).ToList();
                file.Close();
            }
            string html = "";
            foreach (Member member in list)
            {
                html += "<div class=\"grid-itemdsTK\">";
                html += member.Id;
                html += "</div>";
                html += "<div class=\"grid-itemdsTK\">";
                html += member.NickName1;
                html += "</div>";
                html += "<div class=\"grid-itemdsTK\">";
                html += member.Pass;
                html += "</div>";
                html += "<div class=\"grid-itemdsTK\">";
                html += "<button class=\"btnXoa\" value=\"" + member.Id + "\" type=\"submit\" name=\"btnXoaTK\"><i class=\"fa fa-trash\" aria-hidden=\"true\"></i></button>";
                html += "</div>";
                listTK.InnerHtml = html;
            }
            foreach (Member mb in list)
            {
                if (Request.Form["btnXoaTK"] == Convert.ToString(mb.Id))
                {
                    list.Remove(mb);
                    //Ghi file
                    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));

                    System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path));

                    writer.Serialize(_file, list);
                    _file.Close();

                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    break;
                }
            }



        }

        protected void btnAddTK_Click(object o, EventArgs e)
        {
            string path = "listMember.xml";

            List<Member> list = new List<Member>();

            if (File.Exists(Server.MapPath(path)))
            {
                // Đọc file
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));
                StreamReader file = new StreamReader(Server.MapPath(path));

                list = (List<Member>)reader.Deserialize(file);
                list = list.OrderByDescending(Member => Member.Id).ToList();
                file.Close();
            }
            Member mem = new Member();

            mem.Id = list.Count;
            mem.NickName1 = Request.Form["NameTK"];
            mem.Pass = Request.Form["PassTK"];

            bool checktrung = false;
            foreach (Member mb in list)
            {
                if (mb.NickName1 == mem.NickName1)
                {
                    checktrung = true;
                    mb.Id = mem.Id;
                    break;
                }
            }

            if (!checktrung)
            {
                foreach (Member mb in list)
                {
                    if (mb.Id == mb.Id)
                    {
                        mb.Id++;
                    }
                }
                list.Add(mem);
                //Ghi file
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));

                System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path));

                writer.Serialize(_file, list);
                _file.Close();

                Page.Response.Redirect(Page.Request.Url.ToString(), true);
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
