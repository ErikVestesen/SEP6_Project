window.onload = function () {
    this.loadFlights();
    this.Top10Flights();
    this.GetMeanAir();
    this.GetWeather();
} 


function loadFlights() {
    var element = document.getElementById("myfirstchart");

    $.ajax({
        type: "GET",
        url: 'Home/SelectOrigin',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",  
        success: function (response) {
            
            Morris.Bar({
                element: element,
                data: [
                    { y: 'January', a: response.flightsJFK[0], b: response.flightsEWR[0], c: response.flightsLGA[0]},
                    { y: 'Febuary', a: response.flightsJFK[1], b: response.flightsEWR[1], c: response.flightsLGA[1]},
                    { y: 'March', a: response.flightsJFK[2], b: response.flightsEWR[2], c: response.flightsLGA[2] },
                    { y: 'April', a: response.flightsJFK[3], b: response.flightsEWR[3], c: response.flightsLGA[3] },
                    { y: 'May', a: response.flightsJFK[4], b: response.flightsEWR[4], c: response.flightsLGA[4] },
                    { y: 'June', a: response.flightsJFK[5], b: response.flightsEWR[5], c: response.flightsLGA[5] },
                    { y: 'July', a: response.flightsJFK[6], b: response.flightsEWR[6], c: response.flightsLGA[6] },
                    { y: 'August', a: response.flightsJFK[7], b: response.flightsEWR[7], c: response.flightsLGA[7] },
                    { y: 'September', a: response.flightsJFK[8], b: response.flightsEWR[8], c: response.flightsLGA[8] },
                    { y: 'October', a: response.flightsJFK[9], b: response.flightsEWR[9], c: response.flightsLGA[9] },
                    { y: 'November', a: response.flightsJFK[10], b: response.flightsEWR[10], c: response.flightsLGA[10] },
                    { y: 'December', a: response.flightsJFK[11], b: response.flightsEWR[11], c: response.flightsLGA[11]}
                ],
                xkey: 'y',
                ykeys: ['a', 'b', 'c'],
                labels: ['JFK Flights', 'EWR Flights', 'LGA Flights']
            });

            var element2 = document.getElementById("freqStacked");

            Morris.Bar({
                element: element2,
                data: [
                    { y: 'January', a: response.flightsJFK[0], b: response.flightsEWR[0], c: response.flightsLGA[0] },
                    { y: 'Febuary', a: response.flightsJFK[1], b: response.flightsEWR[1], c: response.flightsLGA[1] },
                    { y: 'March', a: response.flightsJFK[2], b: response.flightsEWR[2], c: response.flightsLGA[2] },
                    { y: 'April', a: response.flightsJFK[3], b: response.flightsEWR[3], c: response.flightsLGA[3] },
                    { y: 'May', a: response.flightsJFK[4], b: response.flightsEWR[4], c: response.flightsLGA[4] },
                    { y: 'June', a: response.flightsJFK[5], b: response.flightsEWR[5], c: response.flightsLGA[5] },
                    { y: 'July', a: response.flightsJFK[6], b: response.flightsEWR[6], c: response.flightsLGA[6] },
                    { y: 'August', a: response.flightsJFK[7], b: response.flightsEWR[7], c: response.flightsLGA[7] },
                    { y: 'September', a: response.flightsJFK[8], b: response.flightsEWR[8], c: response.flightsLGA[8] },
                    { y: 'October', a: response.flightsJFK[9], b: response.flightsEWR[9], c: response.flightsLGA[9] },
                    { y: 'November', a: response.flightsJFK[10], b: response.flightsEWR[10], c: response.flightsLGA[10] },
                    { y: 'December', a: response.flightsJFK[11], b: response.flightsEWR[11], c: response.flightsLGA[11] }
                ],
                xkey: 'y',
                ykeys: ['a', 'b', 'c'],
                labels: ['JFK Flights', 'EWR Flights', 'LGA Flights'],
                stacked: true
            });

            var morrisData = [];
            var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
            var count = 0;
            for (var b in response.flightsJFK) {
                var total = response.flightsJFK[b] + response.flightsEWR[b] + response.flightsLGA[b];
                var partJFK = response.flightsJFK[b]; var partEWR = response.flightsEWR[b]; var partLGA = response.flightsLGA[b];
                var percentJFK = (partJFK / total) * 100;
                var percentEWR = (partEWR / total) * 100;
                var percentLGA = (partLGA / total) * 100;
                morrisData.push({ 'y': months[count], 'a': percentJFK, 'b': percentEWR, 'c': percentLGA });
                count = count + 1;
            }

            var element3 = document.getElementById("percentStacked");

            Morris.Bar({
                element: element3,
                data: morrisData,
                xkey: 'y',
                ykeys: ['a', 'b', 'c'],
                labels: ['JFK Flights', 'EWR Flights', 'LGA Flights'],
                stacked: true
            });

        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });
}


function Top10Flights() {
    var element = document.getElementById("topflights");

    $.ajax({
        type: "GET",
        url: 'Home/GetTop10',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var keys = Object.keys(response.top10flights);
            Morris.Bar({
                element: element,
                data: [
                    { y: keys[0], a: response.topflightsJFK[0], b: response.topflightsEWR[0], c: response.topflightsLGA[0] },
                    { y: keys[1], a: response.topflightsJFK[1], b: response.topflightsEWR[1], c: response.topflightsLGA[1] },
                    { y: keys[2], a: response.topflightsJFK[2], b: response.topflightsEWR[2], c: response.topflightsLGA[2] },
                    { y: keys[3], a: response.topflightsJFK[3], b: response.topflightsEWR[3], c: response.topflightsLGA[3] },
                    { y: keys[4], a: response.topflightsJFK[4], b: response.topflightsEWR[4], c: response.topflightsLGA[4] },
                    { y: keys[5], a: response.topflightsJFK[5], b: response.topflightsEWR[5], c: response.topflightsLGA[5] },
                    { y: keys[6], a: response.topflightsJFK[6], b: response.topflightsEWR[6], c: response.topflightsLGA[6] },
                    { y: keys[7], a: response.topflightsJFK[7], b: response.topflightsEWR[7], c: response.topflightsLGA[7] },
                    { y: keys[8], a: response.topflightsJFK[8], b: response.topflightsEWR[8], c: response.topflightsLGA[8] },
                    { y: keys[9], a: response.topflightsJFK[9], b: response.topflightsEWR[9], c: response.topflightsLGA[9] },
                ],
                xkey: 'y',
                ykeys: ['a', 'b', 'c'],
                labels: ['JFK Flights', 'EWR Flights', 'LGA Flights']
            });
        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });
}

function GetMeanAir() {
    var element = document.getElementById("meanAir");

    $.ajax({
        type: "GET",
        url: 'Home/GetMeanAir',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            Morris.Bar({
                element: element,
                data: [
                    { y: response.meanAirtime[0], a: response.meanAirtime[1]},
                    { y: response.meanAirtime[2], a: response.meanAirtime[3]},
                    { y: response.meanAirtime[4], a: response.meanAirtime[5]},
                ],
                xkey: 'y',
                ykeys: ['a'],
                labels: ['Mean airtime minutes']
            });
        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });
}

function GetWeather() {
    var element = document.getElementById("weatherobs");

    $.ajax({
        type: "GET",
        url: 'Home/GetWeather',
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            Morris.Bar({
                element: element,
                data: [
                    { y: response.weatherObservation[0], a: response.weatherObservation[1] },
                    { y: response.weatherObservation[2], a: response.weatherObservation[3] },
                    { y: response.weatherObservation[4], a: response.weatherObservation[5] },
                ],
                xkey: 'y',
                ykeys: ['a'],
                labels: ['Weather observations']
            });
        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });
}