using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiTapLonWeb_VuHuyHoang
{
    public partial class ChitietSP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            string path = "listProduct.xml";

            List<Products> list = new List<Products>();

            if (File.Exists(Server.MapPath(path)))
            {
                // Đọc file
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Products>));
                StreamReader file = new StreamReader(Server.MapPath(path));

                list = (List<Products>)reader.Deserialize(file);
                list = list.OrderByDescending(Product => Product.Id).ToList();
                file.Close();
            }

            Products product = new Products();

            foreach (Products prod in list)
            {
                if (prod.Id == id)
                {
                    product = prod;
                    break;
                }
            }
            imgSP.InnerHtml = "<img src=\"" + product.Url_img + "\" alt=\"\">";
            TenSP.InnerText = product.Tensp;
            GiaSP.InnerHtml = "Deal: " + product.Gia + " đ";
            //btns.Style["background-color"] = "#ff0000";
            btns.InnerHtml =
                             "<p class=\"title\">" + product.Title + "</p>" +
                            "<p class=\"content\">" + product.Content + "</p>";
            //Sản phẩm tương tự
            int count = 0;
            string html = "";
            foreach (Products prod in list)
            {
                if (count < 4)
                {
                    count++;
                }
                else { break; }

                html += "<li>";
                html += "<a style=\"text-decoration:none\"  href=ChiTietSP.aspx?id=" + prod.Id + ">";
                html += "<img src = \"" + prod.Url_img + "\" alt = \"\" >";
                html += "<div class=\"moi_text\" style=\"text-align:center;\">";
                html += "<p style=\"margin - bottom: 5px;\">" + prod.Tensp + "</p>";
                html += "<b class=\"gia\" style=\"color: red; font - size: 25px;\">" + prod.Gia + "đ </b>";
                html += "<p class=\"content\">" + prod.Title + "</p>";
                //html += "<div style=\"color:#2cc067;\"><i class=\"fa-solid fa-check\"></i>Còn hàng</div>";
                html += "<button style = \" \" class=\"mua\">Thích<i class=\"fa-sharp fa-solid fa-heart\"></i></button>";
                html += "</div>";
                html += "</a>";
                html += "</li>";
            }
            ListSale.InnerHtml = html;
            //List<DsSanPham> DsSP;
            //if (Request.Form["add-cart-list"] != null)
            //{
            //    DsSP = (List<DsSanPham>)Application["DsSanPham"];
            //    if ((bool)Session["login"] == true)
            //    {
            //        DsSanPham dssp = new DsSanPham((string)Convert.ToString(Session["id"]), Convert.ToInt32(Request.Form["add-cart-list"]));


            //        DsSP.Add(dssp);

            //        Application["DsSanPham"] = DsSP;
            //        Response.Redirect("GioHang.aspx");
            //    }
            //}
        }
        protected void btnAdd_click(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["id"]);
            List<DsSanPham> cart = Session[Global.LIST_LIKED] as List<DsSanPham>;
            DsSanPham sp = cart.FirstOrDefault(o => o.Id == ID);
            if (sp == null)
            {
                sp = new DsSanPham();
                sp.Id = ID;
                sp.count = 1;
                cart.Add(sp);
            }
            else sp.count++;
            Session[Global.LIST_LIKED] = cart;
            Response.Redirect(Request.UrlReferrer.ToString());

        }
        protected void btnRemove_click(object sender, EventArgs e)
        {
            

            Response.Redirect("QuanLySp.aspx");
        }
    }
}
