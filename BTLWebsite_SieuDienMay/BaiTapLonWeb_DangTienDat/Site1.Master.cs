using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiTapLonWeb_VuHuyHoang
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string html = "";
            html += "<i class=\"fa-solid fa-user\"></i><button id=\"dropbtn\">Tài khoản<i class=\"fa-solid fa-caret-down\" style=\"margin-left: 5px;\"></i></button>" +
                "</a>";
            if ((bool)Session["login"] == true && (string)Session["TK"] == "admin")
            {
                html += "<div id=\"drd-content\">";
                html += "<b>ID: " + Session["id"] + "</b><br/>";
                html += "<b>TK: " + Session["TK"] + "</b>";
                html += "<a href=\"QuanLySP.aspx\">Quản lý sản phẩm</a>";
                html += "<a href=\"QuanLyTaiKhoan.aspx\">Quản lý tài khoản</a>";
                html += "<form><button type=\"submit\" value=\"true\" name=\"btnLogout\" id=\"btnLogout\" runat=\"server\">" +
                                "<i class=\"fa fa-power-off\" aria-hidden=\"true\"></i> Thoát" +
                            "</button></form>";
                html += "</div>";
                account.InnerHtml = html;
            }
            else if ((bool)Session["login"] == true)
            {
                html += "<div id=\"drd-content\">";
                html += "<b>ID: " + Session["id"] + "</b><br/>";
                html += "<b>TK: " + Session["TK"] + "</b>";
                html += "<form><button type=\"submit\" value=\"true\" name=\"btnLogout\" id=\"btnLogout\" runat=\"server\">" +
                                "<i class=\"fa fa-power-off\" aria-hidden=\"true\"></i> Thoát" +
                            "</button></form>";
                html += "</div>";
                account.InnerHtml = html;
            }
            else
            {
                html += "<div id=\"drd-content\">";
                html += "<a href=\"Dangnhap.aspx\" ><i class=\"fa-solid fa-right-to-bracket\"></i>Đăng nhập</a>";
                html += "<a href=\"Dangky.aspx\" ><i class=\"fa-solid fa-registered\"></i>Đăng ký</a>";
                html += "</div>";
                account.InnerHtml = html;
            }
            if (Request.QueryString["btnLogout"] == "true")
            {
                Session.Abandon();

                Response.Redirect("Dangnhap.aspx");
            }
        }
    }
}