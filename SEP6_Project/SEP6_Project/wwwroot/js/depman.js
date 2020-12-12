window.onload = function () {
    this.loadDepArr();
    this.GetBigManufacturers();
    this.GetManufacturersFlight();
    this.GetAirbusModels();
} 


function loadDepArr() {

    $.ajax({
        type: "GET",
        url: 'GetMeanDepArr',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });
};

function GetBigManufacturers() {

    $.ajax({
        type: "GET",
        url: 'GetBigManufacturers',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });

};

function GetManufacturersFlight() {

    $.ajax({
        type: "GET",
        url: 'GetManufacturersFlight',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });
};

function GetAirbusModels() {
    $.ajax({
        type: "GET",
        url: 'GetAirbusModels',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {

        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });
}
