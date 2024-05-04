<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChitietSP.aspx.cs" Inherits="BaiTapLonWeb_VuHuyHoang.ChitietSP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/ChitietSP.css" rel="stylesheet" />
    <link href="Css/CssMaster.css" rel="stylesheet" />
    <link href="Css/TrangChu.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="chitietSp">
        <div id="sp-left"  style="width:30%;" >
            <div id="imgSP" name="imgSP" runat="server">

            </div>
        </div>
        <div id="sp-right" style="width: 70%; line-height: 42px;">
            <p id="TenSP" name="TenSP" runat="server">


            </p>
            <div class="" style="font-size:20px;">
				<i class="fa fa-star" aria-hidden="true"></i>
				<i class="fa fa-star" aria-hidden="true"></i>
				<i class="fa fa-star" aria-hidden="true"></i>		
				<i class="fa fa-star" aria-hidden="true"></i>
				<i class="fa fa-star-o" aria-hidden="true"></i>
			</div>
            <div style="color: red;" id="GiaSP" name="GiaSP" runat="server">

            </div>
            <div><b>Bảo hành: </b>12 tháng</div>
            <%--<div><b>Tình trạng:</b><span style="color: #2cc067;"><i class="fa-solid fa-check"></i>Còn hàng</span></div>--%>
            <div class="sp-mua">
                <button type="button" class="mua" id="like" runat="server" OnServerClick="btnAdd_click">Thích<i class="fa-sharp fa-solid fa-heart"></i></button>
                <button type="button" class="mua" id="Remove" runat="server" OnServerClick="btnRemove_click">Xoá</button>
                <div id="btns" name="btns" runat="server">

                </div>
            </div>  
        </div>
    </div>
 
        <div id="T_moi">
            <p id="SpMoi" style="font-size:26px">Sản phẩm tương tự</p><hr />
                <ul class="list_moi" id="ListSale" Name="ListSale" runat="server">
                       
                </ul>
        </div>
    <script>
    function detail(){
        document.getElementById("detail").style.display="none";
    }
    </script>
    <style>
        .title{
            color: red;
            font-weight: bold;
        }

    </style>
</asp:Content>
