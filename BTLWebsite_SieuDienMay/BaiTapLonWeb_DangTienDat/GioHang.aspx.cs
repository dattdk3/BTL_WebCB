using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace BaiTapLonWeb_VuHuyHoang
{
    public partial class GioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = Server.MapPath("listProduct.xml");
            List<DsSanPham> cart = Session[Global.LIST_LIKED] as List<DsSanPham>;
            List<Products> list = new List<Products>();

            if (File.Exists(path))
            {
                // Đọc file XML
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Products>));
                using (StreamReader file = new StreamReader(path))
                {
                    list = (List<Products>)reader.Deserialize(file);
                }

                // Lọc danh sách sản phẩm đã thích từ danh sách sản phẩm đọc từ tệp XML
                List<Products> likedProducts = new List<Products>();
                foreach (DsSanPham cartItem in cart)
                {
                    Products likedProduct = list.Find(p => p.Id == cartItem.Id);
                    if (likedProduct != null)
                    {
                        likedProducts.Add(likedProduct);
                    }
                }
                Products product = new Products();
                // Hiển thị danh sách sản phẩm đã thích lên trang web
                string html = "<table>";
                foreach (Products item in likedProducts)
                {
                    int count = cart.FirstOrDefault(p => p.Id == item.Id).count;
                    //html += "<tr>";
                    //html += "<th><img src=\"" + item.Url_img + "\" width=\"50%\" height=\"50%\" alt=\"\"></td>";
                    //html += "<td>" + item.Tensp + "</td>";
                    //html += "<td>" + item.Gia + "</td>";
                    //html += "<td>" + item.Title + "</td>";
                    ////html += "<td>" + count + "</td>";
                    //html += "<td><button class='btn btn-basic' type='submit' value='" + item.Id + "' id='btnXoa' name='btnXoa' runat='server'>" +
                    //                    "<i class='fa fa-trash' aria-hidden='true'></i> Xóa" +
                    //                "</button></td>";
                    //html += "</tr>";

                    html += "<tr>";
                    html += "<th><a href=ChiTietSP.aspx?id="+item.Id+"><img src=\"" + item.Url_img + "\" width=\"50%\" height=\"50%\" alt=\"\"></a></th>";
                    html += "<th>" + item.Tensp + "</th>";
                    html += "<th>" + item.Gia + "</th>";
                    html += "<th>" + item.Title + "</th>";
                    //html += "<th>" + count + "</th>";
                    html += "<th><button class='btn btn-basic' type='submit' value='" + item.Id + "' id='btnXoa' name='btnXoa' runat='server'>" +
                                        "<i class='fa fa-trash' aria-hidden='true'></i> Xóa" +
                                    "</button></th>";
                    html += "</tr>";
                }
                html += "</table>";

                listCart.InnerHtml = html; // Hiển thị danh sách sản phẩm lên giao diện
            }

            //if (!IsPostBack)
            //{
            //    if (Session[Global.LIST_LIKED] != null)
            //    {
            //        List<DsSanPham> likedProducts = (List<DsSanPham>)Session[Global.LIST_LIKED];


            //        string html = "";
            //        int i = 0;

            //        XDocument doc = XDocument.Load(Server.MapPath("~/listproduct.xml"));
            //        foreach (DsSanPham productId in likedProducts)
            //        {
            //            XElement product = doc.Descendants("Product")
            //                                  .FirstOrDefault(p => p.Element("Id").Value == productId.ToString());
            //            if (product != null)
            //            {
            //                html += "<tr>";
            //                html += "<th>" + "<img src = \"" + product.Element("Url_img") + "\" width=\"50%\" height=\"50%\" alt = \"\" >" + "</th>";
            //                html += "<th>" + product.Element("Tensp").Value + "</th>";
            //                html += "<th>" + product.Element("Giasp").Value + "</th>";
            //                html += "<th>" + product.Element("Title") + "</th>";
            //                html += "<th><button class='btn btn-basic' type='submit' value='" + product.Element("Id") + "' id='btnXoa' name='btnXoa' runat='server'>" +
            //                                        "<i class='fa fa-trash' aria-hidden='true'></i> Xóa" +
            //                                    "</button></th>";
            //                html += "</tr>";
            //            }

            //        }

            //        listCart.InnerHtml = html;
            //        string path = "listProduct.xml";

            //        List<Products> list = new List<Products>();

            //        if (File.Exists(Server.MapPath(path)))
            //        {
            //            // Đọc file
            //            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Products>));
            //            StreamReader file = new StreamReader(Server.MapPath(path));

            //            list = (List<Products>)reader.Deserialize(file);
            //            list = list.OrderByDescending(Product => Product.Id).ToList();
            //            file.Close();
            //        }
            //    }

            //string html = "";
            //int i = 0;
            //foreach (DsSanPham cart in idcarts)
            //{
            //    i++;
            //    if ((string)Convert.ToString(Session["id"]) == cart.IdMb)
            //    {
            //        Products find_Product = list.Find(item => item.Id == cart.IdProd && cart.IdMb == Convert.ToString(Session["id"]));


            //        if (find_Product != null)
            //        {
            //            html += "<tr>";
            //            html += "<th>" + "<img src = \"" + find_Product.Url_img + "\" width=\"50%\" height=\"50%\" alt = \"\" >" + "</th>";
            //            html += "<th>" + find_Product.Tensp + "</th>";
            //            html += "<th>" + find_Product.Gia + "</th>";
            //            html += "<th>" + find_Product.Title + "</th>";
            //            html += "<th><button class='btn btn-basic' type='submit' value='" + find_Product.Id + "' id='btnXoa' name='btnXoa' runat='server'>" +
            //                                    "<i class='fa fa-trash' aria-hidden='true'></i> Xóa" +
            //                                "</button></th>";
            //            html += "</tr>";

            //        }
            //    }
            //    listCart.InnerHtml = html;
            //}


            //    if (Request.Form["btnXoa"] != null)
            //    {
            //        idcarts = (List<DsSanPham>)Session[Global.LIST_LIKED];
            //        var itemToRemove = idcarts.SingleOrDefault(pro => pro.IdProd == Convert.ToInt32(Request.Form["btnXoa"]));
            //        if (itemToRemove != null)
            //            idcarts.Remove(itemToRemove);
            //        Session[Global.LIST_LIKED] = idcarts;
            //        Response.Redirect("GioHang.aspx");
            //    }
            //    int tong = 0;
            //    foreach (DsSanPham cart in idcarts)
            //    {
            //        i++;
            //        if ((string)Convert.ToString(Session["id"]) == cart.IdMb)
            //        {
            //            Products find_Product = list.Find(item => item.Id == cart.IdProd && cart.IdMb == Convert.ToString(Session["id"]));


            //            if (find_Product != null)
            //            {
            //                tong += find_Product.Gia;
            //            }
            //        }
            //    }
            //    TongTien.InnerHtml = "<b>" + tong + "</b>";
            //}

        }
    }
}
