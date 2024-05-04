function login_show() {
    var show = document.getElementById("pass_dn");
    show.setAttribute('type', 'text');
}
function login_hide() {
    var hide = document.getElementById("pass");
    hide.setAttribute('type', 'password');
}

var BienShow = 0;
document.getElementById("eye").addEventListener("click", function () {
    if (BienShow == 0) {
        BienShow = 1;
        login_show();
    }
    else {
        BienShow = 0;
        login_hide();
    }
}, false);

//function missing(productId) {
//    var a = confirm("Bạn có chắc chắn:" + productId);
//    window.location
//}