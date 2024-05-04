using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiTapLonWeb_VuHuyHoang
{
    public partial class TrangChuaspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            int count = 0;
            string html = "";
            foreach (Products product in list)
            {
                if (count < 4)
                {
                    count++;
                }
                else { break; }

                html += "<li>";
                html += "<a style=\"text-decoration:none\"  href=ChiTietSP.aspx?id=" + product.Id + ">";
                html += "<img src = \"" + product.Url_img + "\" alt = \"\" >";
                html += "<div class=\"moi_text\" style=\"text-align:center;\">";
                html += "<p style=\"margin - bottom: 5px;\">" + product.Tensp + "</p>";
                html += "<b class=\"gia\" style=\"color: red; font - size: 25px;\">" + product.Gia + "</b>";
                html += "<p class=\"content\">" + product.Title + "</p>";
                //html += "<div style=\"color:#2cc067;\"><i class=\"fa-solid fa-check\"></i>Còn hàng</div>";
               // html += "<button style = \" \" class=\"mua\" OnClick=\"btnAdd_click('" + product.Id + "')\">Thích <i class=\"fa-sharp fa-solid fa-heart\"></i></button>";
                html += "</div>";
                html += "</a>";
                html += "</li>";
            }
            listSPmoi.InnerHtml = html;

            string html1 = "";
            int count1 = 0;
            foreach (Products product in list)
            {
                if (count1 < 8)
                {
                    count1++;
                }
                else { break; }

                html1 += "<li>";
                html1 += "<a style=\"text-decoration:none\"  href=ChiTietSP.aspx?id=" + product.Id + ">";
                html1 += "<img src = \"" + product.Url_img + "\" alt = \"\" >";
                html1 += "<div class=\"moi_text\" style=\"text-align:center;\">";
                html1 += "<p style=\"margin - bottom: 5px;\">" + product.Tensp + "</p>";
                html1 += "<b class=\"gia\" style=\"color: red; font - size: 25px;\">" + product.Gia + "</b>";
                html1 += "<p class=\"content\">" + product.Title + "</p>";
                //html1 += "<div style=\"color:#2cc067;\"><i class=\"fa-solid fa-check\"></i>Còn hàng</div>";
               // html1 += "<button class=\"mua\" 'OnClick=\"btnAdd_click('" + product.Id + "')\"'>Thích <i class=\"fa-sharp fa-solid fa-heart\"></i></button>";
                html1 += "</div>";
                html1 += "</a>";
                html1 += "</li>";
            }
            ListSale.InnerHtml = html1;
        }
        // Xử lý sự kiện click vào nút thích
        // Xử lý sự kiện click vào nút thích
        public static void btnAdd_click(int productId)
        {
            List<int> likedProducts = new List<int>();

            if (HttpContext.Current.Session["ListLiked"] != null)
            {
                likedProducts = (List<int>)HttpContext.Current.Session["ListLiked"];
            }

            likedProducts.Add(productId);

            HttpContext.Current.Session["ListLiked"] = likedProducts;
            // Trả về một thông báo cho client-side JavaScript để hiển thị
            string script = "<script>alert('Sản phẩm đã được thêm vào danh sách yêu thích.');</script>";
            HttpContext.Current.Response.Write(script);
        }

        // Tạo trang hiển thị các sản phẩm đã thích


    }
}
