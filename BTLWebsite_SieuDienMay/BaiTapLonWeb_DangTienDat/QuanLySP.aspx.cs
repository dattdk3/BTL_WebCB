using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BaiTapLonWeb_VuHuyHoang
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["TK"] != "admin" || (bool)Session["login"] == false)
            {
                Response.Redirect("TrangChu.aspx");
            }
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
            string html = "";

            foreach (Products product in list)
            {
                html += "<div class=\"grid-itemdsSP\">";
                html += product.Id;
                html += "</div>";
                html += "<div class=\"grid-itemdsSP\">";
                html += "<img src =\"" + product.Url_img + "\" width=\"50%\" height=\"\" alt=\"\">";
                html += "</div>";
                html += "<div class=\"grid-itemdsSP\">";
                html += product.Tensp;
                html += "</div>";
                html += "<div class=\"grid-itemdsSP\">";
                html += product.Gia;
                html += "</div>";
                html += "<div class=\"grid-itemdsSP\">";
                html += "<button class=\"btnXoa\" value=\"" + product.Id + "\" type=\"submit\" name=\"btnXoa\"><i class=\"fa fa-trash\" aria-hidden=\"true\"></i></button>";
                html += "</div>";
                listproduct.InnerHtml = html;
            }

            foreach (Products product in list)
            {
                if (Request.Form["btnXoa"] == Convert.ToString(product.Id))
                {
                    list.Remove(product);
                    //Ghi file
                    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Products>));

                    System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path));

                    writer.Serialize(_file, list);
                    _file.Close();

                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    break;
                }
            }
        }

        private bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        protected void btnUpLoad_Click(object o, EventArgs e)
        {
            if (Page.IsValid && ImgProduct.HasFile)
            {
                if (CheckFileType(ImgProduct.FileName))
                {
                    string fileName = "img/" + ImgProduct.FileName;
                    string filePath = MapPath(fileName);
                    ImgProduct.SaveAs(filePath);
                    Image1.ImageUrl = fileName;
                }
                else
                {
                    string alert = "";
                    alert += "<script>alert('Chỉ nhận file ảnh!!!');</script>";
                    Response.Write(alert);
                }
            }
        }


        protected void btnAddProd_Click(object o, EventArgs e)
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

            Products prod = new Products();

            prod.Id = list.Count;
            prod.Tensp = Request.Form["NameProduct"];
            prod.Gia = int.Parse(Request.Form["GiaProd"]);
            prod.Url_img = Image1.ImageUrl;

            bool checktrung = false;
            foreach (Products product in list)
            {
                if (product.Tensp == prod.Tensp)
                {
                    checktrung = true;
                    product.Id = prod.Id;
                    break;
                }
            }

            if (!checktrung)
            {
                foreach (Products product in list)
                {
                    if (product.Id == prod.Id)
                    {
                        prod.Id++;
                    }
                }
                list.Add(prod);
                //Ghi file
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<Products>));

                System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path));

                writer.Serialize(_file, list);
                _file.Close();

                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                string alert = "";
                alert += "<script>alert('Mặt hàng đã tồn tại!');</script>";
                Response.Write(alert);
            }
        }
    }
}