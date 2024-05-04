<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QuanLyTaiKhoan.aspx.cs" Inherits="BaiTapLonWeb_VuHuyHoang.QuanLyTaiKhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="Css/QuanLyTaiKhoan.css"/>
    <div class="boxQLTK">
        <h2 style="text-align:center;padding:20px;">Quản lý tài khoản</h2><hr />
        <div class="container-QLTK">
            <div class="grid-itemTK" >
                Tên đăng nhập
            </div>
            <div class="grid-itemTK">
                <input type="text" id="NameTK" name="NameTK" placeholder="Tên tài khoản"/>
            </div>
            <div class="grid-itemTK">
                Mật khẩu
            </div>
            <div class="grid-itemTK">
                <input type="text" id="PassTK" name="PassTK" placeholder="Mật khẩu" />
            </div>  
        </div>
        <center> 
                <asp:button text="Thêm" runat="server" ID="btnAddTK" OnClick="btnAddTK_Click" Height="20px" Width="200px" />
		</center>
        <br />
        <hr />
        <br />
        <div class="container-DSTK">
            <div class="grid-itemdsTK">
                ID
            </div>
            <div class="grid-itemdsTK">
                Tài khoản
            </div>
            <div class="grid-itemdsTK">
                Mật khẩu
            </div>
            <div class="grid-itemdsTK">
                Xóa
            </div>
        </div>
        <div class="container-DSTK" id="listTK" Name="ListTK" runat="server">

        </div>
        <hr />
    </div>
</asp:Content>
