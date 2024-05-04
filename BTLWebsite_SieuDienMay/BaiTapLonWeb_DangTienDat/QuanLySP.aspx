<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QuanLySP.aspx.cs" Inherits="BaiTapLonWeb_VuHuyHoang.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/QuanLySp.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="boxQLSP">
        <h2 style="text-align:center;padding:20px;">Quản lý sản phẩm</h2><hr />
        <div class="container-QLSP">
            <div class="grid-itemSP" >
                Tên sản phẩm:
            </div>
            <div class="grid-itemSP">
                <input type="text" id="NameProduct" name="NameProduct" placeholder="Tên sản phẩm"/>
            </div>
            <div class="grid-itemSP">
                Giá:
            </div>
            <div class="grid-itemSP">
                <input type="number" id="GiaProduct" name="GiaProd" placeholder="1000000" />
            </div>
            <div class="grid-itemSP">
                Ảnh sản phẩm:
            </div>
            <div class="grid-itemSP">
                <asp:FileUpload ID="ImgProduct" runat="server" name="myImage" />
            </div>
            <div class="grid-itemSP">
                <asp:Button ID="btnUpLoad" runat="server" Text="Upload" OnClick="btnUpLoad_Click"/>
            </div>
            <div class="grid-itemSP" >
                <asp:Image ID="Image1" runat="server" CssClass="imgView" />
            </div>
            
        </div>
        <center> 
                <asp:button text="Thêm" runat="server" ID="btnAddProd" OnClick="btnAddProd_Click" Height="20px" Width="200px" />
		</center>
        <br />
        <hr />
        <br />
        <div class="container-DSSP">
            <div class="grid-itemdsSP">
                ID
            </div>
            <div class="grid-itemdsSP">
                Hình ảnh
            </div>
            <div class="grid-itemdsSP">
                Tên sản phẩm
            </div>
            <div class="grid-itemdsSP">
                Giá
            </div>
            <div class="grid-itemdsSP">
                Xóa
            </div>
        </div>
        <div class="container-DSSP" id="listproduct" Name="ListProducts" runat="server">

        </div>
        <hr />
    </div>
</asp:Content>
