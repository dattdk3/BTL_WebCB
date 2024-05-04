<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GioHang.aspx.cs" Inherits="BaiTapLonWeb_VuHuyHoang.GioHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/GioHang.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"
        rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tong">
        <div class="nav">
            <div class="nav-link-a">
                <a href="Trangchu.aspx">Trang chủ</a>>>giỏ hàng
            </div>
        </div>
        <div class="well well-small">
            <h1 class="well-small-text">Các sản phẩm đã yêu thích<br>
                <small class="pull-right">Sản phẩm </small></h1>
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col">image</th>
                        <th scope="col">name</th>
                        <th scope="col">price</th>
                        <th scope="col">title</th>
                        <th scope="col">action</th>
                    </tr>
                </thead>
                <tbody id="listCart" runat="server">
                    
                </tbody>
            </table>


            <br />
            <div class="well-quaytrang">
                <a href="Sanpham.aspx" class="well-quaytrang-a">
                    <button type="button" class="well-quaytrang-btn">
                        <i class="fa-solid fa-arrow-left"></i>Tiếp tục xem sản phẩm
                    </button>
                </a>

            </div>
            <div class="clear"></div>
            <div class="khoangcach"></div>
        </div>
    </div>
</asp:Content>
