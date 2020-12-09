window.onload = function () {
    this.loadTemps();
}


function loadTemps() {
    var element = document.getElementById("myfirstchart");

    $.ajax({
        type: "GET",
        url: 'Temp/GetTempModel',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Something Right.");
        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });
}


