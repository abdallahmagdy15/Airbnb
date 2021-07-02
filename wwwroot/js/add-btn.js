var btn = document.getElementById('addbtn');
var nodes = document.querySelectorAll("#main-admin-page input[type=text]");

$("#main-admin-page input[type=text]").keyup(function () {
    console.log("a")
    for (var i = 0; i < nodes.length; i++) {
        if (nodes[i].value == "") {
            btn.disabled = true;
            break;
        } else {
            btn.disabled = false;
        }
    }
    if (btn.disabled == false) {
        btn.disabled = false;
    }

})