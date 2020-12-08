window.onload = function () {
    this.loadFlights();
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
        },
        error: function (e) {
            alert("Something Wrong.");
        }
    });
}