window.onload = function () {
    this.loadMeanTempJFK();
    this.loadAllMean();
}

function loadMeanTempJFK() {
    var element = document.getElementById("meanTempChartJFK");

    $.ajax({
        type: "GET",
        url: 'loadMeanJFK',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var morrisData = [];
            for (var b in response.mean_JFK) {
                //var d = new Date(response.temp_JFK[b].year, response.temp_JFK[b].month, response.temp_JFK[b].day);
                var d = response.mean_JFK[b].year + "-" + response.mean_JFK[b].month + "-" + response.mean_JFK[b].day;
                morrisData.push({ 'Day': d, 'Temp': response.mean_JFK[b].daily_mean });
            }

            new Morris.Line({
                element: element,
                data: morrisData,
                xkey: 'Day',
                ykeys: ['Temp'],
                labels: ['Temp']
            });
        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });
}

function loadAllMean() {
    var element = document.getElementById("meanTempAll");

    $.ajax({
        type: "GET",
        url: 'meanTempAll',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var morrisData = [];
            for (var b in response.mean_JFK) {
                //var d = new Date(response.temp_JFK[b].year, response.temp_JFK[b].month, response.temp_JFK[b].day);
                var d = response.mean_JFK[b].year + "-" + response.mean_JFK[b].month + "-" + response.mean_JFK[b].day;
                morrisData.push({ 'Day': d, 'JFK': response.mean_JFK[b].daily_mean, 'EWR': response.mean_EWR[b].daily_mean, 'LGA': response.mean_LGA[b].daily_mean  });
            }

            new Morris.Line({
                element: element,
                data: morrisData,
                xkey: 'Day',
                ykeys: ['JFK', 'EWR', 'LGA'],
                labels: ['Temp JFK', 'Temp EWR', 'Temp LGA'],
                lineColors: ['#1B94E0', '#E00B0B', '#69CF89'],
                pointSize: 2
            });
        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });
}


