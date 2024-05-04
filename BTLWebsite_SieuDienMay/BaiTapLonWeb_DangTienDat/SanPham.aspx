<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SanPham.aspx.cs" Inherits="BaiTapLonWeb_VuHuyHoang.SanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/SanPham.css" rel="stylesheet" />
    <link href="Css/CssMaster.css" rel="stylesheet" />
    <link href="Css/TrangChu.css" rel="stylesheet" />
    <link href="Css/responsive.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div id="Sanpham">
    <div id="T_moi">
      <div id="s_head" style="text-align: center;font-size: 28px;">Sản phẩm của Shop</div>
      <div class="big">
        <div class="cot1">
          <a class="dong1" href="ChiTietSP.aspx">
            <div class="cottrai1"><i class="fas fa-mobile-alt"></i></div>
            <div class="cotphai1">Điện Thoại </div>
          </a>
         
          <a class="dong1" href="ChiTietSP.aspx">
            <div class="cottrai1"><i class="far fa-clock"></i></div>
            <div class="cotphai1">Apple Watch </div>
          </a>
          <a class="dong1" href="ChiTietSP.aspx">
            <div class="cottrai1"><i class="fa-solid fa-laptop-code"></i></div>
            <div class="cotphai1">Máy tính-Laptop </div>
          </a>
          <a class="dong1" href="ChiTietSP.aspx">
            <div class="cottrai1"><i class="fa-solid fa-tv"></i></div>
            <div class="cotphai1">Tivi</div>
          </a>
          <a class="dong1" href="ChiTietSP.aspx">
            <div class="cottrai1"><i class="fas fa-snowflake"></i></div>
            <div class="cotphai1">Đồ Điện Tử </div>
          </a>
        </div>

        <ul class="list_moi" id="listSP" name="listSP" runat="server">
          
        </ul>
        </div>
    </div>
</div>
   <%-- <script>
        function likeProduct(productId) {
            // Thực hiện xử lý khi người dùng nhấn nút "Thích"
            // Chẳng hạn, bạn có thể sử dụng AJAX để gửi yêu cầu đến máy chủ để lưu sản phẩm đã thích
            // Sau đó, chuyển hướng người dùng đến trang đã thích
            window.location.href = "GioHang.aspx?productId=" + productId;
        }

    </script>--%>
</asp:Content>
