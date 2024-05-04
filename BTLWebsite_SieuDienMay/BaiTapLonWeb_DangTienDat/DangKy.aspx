<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="BaiTapLonWeb_VuHuyHoang.DangKy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Css/DangKy.css">
    <script src="Js/DangKy.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form_regis">
        <form action="">
            <div class="R_form">
                <header>
                    <h2 style="margin: 0px auto;">Đăng ký thành viên mới</h2>
                </header>
                <br>
                <div class="register">
                    <div class="user in">
                        <!-- username -->
                        <div id="error_user"></div>
                        <span class="R_icon"><i class="fa fa-user-circle"></i></span>
                        <input class="form-input" id="username" name="username" type="text" placeholder="@UserName" required>

                    </div>
                    <br>
                    <div class="pass in">
                        <!-- password -->

                        <span class="R_icon"><i class="fa-solid fa-key"></i></span>
                        <input class="form-input" id="pass" type="password" placeholder="Password" name="pass"
                            required>
                    </div>
                    <br>
                    <div class="passCon in">
                        <!-- password confirm -->

                        <span class="R_icon"><i class="fa-solid fa-key"></i></span>
                        <input class="form-input" id="passC" type="password" placeholder="Confirm Password" name="passC"
                            required>
                    </div>
                </div>
                <br>
                <button class="non-actsive" type="submit" name="btnSignUp" value="true" id="btnSignUp">Đăng ký</button><br /><br />           
            </div>    
        </form>
        <a href="Dangnhap.aspx" class="backLog">Đã có tài khoản</a>
    </div>
        <script src="JS/regis.js"></script>
</asp:Content>
