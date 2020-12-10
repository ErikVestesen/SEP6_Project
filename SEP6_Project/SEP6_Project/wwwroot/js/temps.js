window.onload = function () {
    this.loadAllTempJFK();
    this.loadAllTempEWR();
    this.loadAllTempLGA();
}

async function loadAllTempJFK() {
    var element = document.getElementById("tempChartJFK");

    $.ajax({
        type: "GET",
        url: 'loadTempJFK',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: await function (response) {
            var morrisData = [];
            for (var b in response.temp_JFK) {
                //var d = new Date(response.temp_JFK[b].year, response.temp_JFK[b].month, response.temp_JFK[b].day);
                var d = response.temp_JFK[b].year + "-" + response.temp_JFK[b].month + "-" + response.temp_JFK[b].day;
                morrisData.push({ 'Day': d, 'Temp': response.temp_JFK[b].daily_mean });
            }

            new Morris.Line({
                element: element,
                data: morrisData,
                xkey: 'Day',
                ykeys: ['Temp'],
                labels: ['Temp'],
                pointSize: 2
            });
        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });
}

async function loadAllTempEWR() {
    var element = document.getElementById("tempChartEWR");

    $.ajax({
        type: "GET",
        url: 'loadTempEWR',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var morrisData = [];
            for (var b in response.temp_EWR) {
                //var d = new Date(response.temp_JFK[b].year, response.temp_JFK[b].month, response.temp_JFK[b].day);
                var d = response.temp_EWR[b].year + "-" + response.temp_EWR[b].month + "-" + response.temp_EWR[b].day;
                morrisData.push({ 'Day': d, 'Temp': response.temp_EWR[b].daily_mean });
            }

            new Morris.Line({
                element: element,
                data: morrisData,
                xkey: 'Day',
                ykeys: ['Temp'],
                labels: ['Temp'],
                pointSize: 2
            });
        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });
}

async function loadAllTempLGA() {
    var element = document.getElementById("tempChartLGA");

    $.ajax({
        type: "GET",
        url: 'loadTempLGA',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var morrisData = [];
            for (var b in response.temp_LGA) {
                //var d = new Date(response.temp_JFK[b].year, response.temp_JFK[b].month, response.temp_JFK[b].day);
                var d = response.temp_LGA[b].year + "-" + response.temp_LGA[b].month + "-" + response.temp_LGA[b].day;
                morrisData.push({ 'Day': d, 'Temp': response.temp_LGA[b].daily_mean });
            }

            new Morris.Line({
                element: element,
                data: morrisData,
                xkey: 'Day',
                ykeys: ['Temp'],
                labels: ['Temp'],
                pointSize: 2
            });
        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });
}

