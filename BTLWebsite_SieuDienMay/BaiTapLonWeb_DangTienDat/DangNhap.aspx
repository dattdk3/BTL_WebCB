<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="BaiTapLonWeb_VuHuyHoang.DangNhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Css/DangNhap.css">
    <script src="Js/DangNhap.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form_login">
        <form method="post">
            <div class="L_form">
                <header class="head">
                    <h2 style="margin:0px auto;">Đăng nhập</h2><br>
                </header>
                <p style="text-align:center;">Sử dụng tài khoản và mật khẩu để đăng nhập</p>
                <br>
                <div class="login">
                    <div class="user in">
                        <!-- username -->

                        <span class="L_icon"><i class="fa fa-user-circle"></i></span>
                        <input class="form-input" id="txt-input" name="usn" type="text" placeholder="@UserName" required>

                    </div>
                    <br>
                    <div class="pass in">
                        <!-- password -->

                        <span class="L_icon"><i class="fa-solid fa-key"></i></span>
                        <input class="form-input" id="pass_dn" type="password" placeholder="Password" name="password"
                            required>
                        <span><i class="fa-regular fa-eye" id="eye"></i></span>

                    </div>
                </div>
                <br>
                <!-- button LogIn -->
                <span><button class="btn-login" id="btnLogin" runat="server" OnServerClick="btn_For_login" value="true" name="btnLogin">Đăng Nhập</button></span>
                <br>
                <p id="hoac">hoặc</p>
                <br>
                <span><button class="btnlogin" ><a href="Dangky.aspx" style="text-decoration:none">Đăng Ký Tài Khoản Mới<i class="fa fa-user-plus"
                            aria-hidden="true"></i></a> </button></span>
            </div>
        </form>
        </div>
        <script src="JS/login.js"></script>
</asp:Content>
