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

            alert(response);
            

            Morris.Bar({
                element: element,
                data: [
                    { y: 'January', a: response[0]},
                    { y: 'Febuary', a: response[1]},
                    { y: 'March', a: response[2]},
                    { y: 'April', a: response[3] },
                    { y: 'May', a: response[4] },
                    { y: 'June', a: response[5]},
                    { y: 'July', a: response[6] },
                    { y: 'August', a: response[7] },
                    { y: 'September', a: response[8]},
                    { y: 'October', a: response[9]},
                    { y: 'November', a: response[10]},
                    { y: 'December', a: response[11], b: 3100, c:2800 } //b and c should be collected values of EWR and LGA
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