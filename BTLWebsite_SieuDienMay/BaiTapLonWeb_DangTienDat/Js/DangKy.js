$(document).ready(function (e) {
    //Kiem tra dang ký
    var user = document.getElementById('username').value;
    var pass = document.getElementById('pass').value;
    var passC = document.getElementById('passC').value;
    var btnSignUp = document.getElementById("btnSignUp");
    if (pass && passC) {
        pass.addEventListener("blur", () => {
            if (pass.value == passC.value) {
                btnSignUp.classList.remove("non-active");
            }
            else {
                alert("Mật khẩu không khớp!!!");
            }
        });
    }

    if (btnSignUp && user && pass && passC) {
        btnSignUp.addEventListener("mousemove", () => {
            if (user.value == "") {
                alert("Bạn chưa nhập Email.");
            } else if (pass.value == "") {
                alert("Bạn chưa nhập mật khẩu.");
            } else if (passC.value == "") {
                alert("Bạn chưa nhập lại mật khẩu.");
            } else if (pass.value != passC.value) {
                btnSignUp.classList.add("non-active");
            }
        });
    }
});
