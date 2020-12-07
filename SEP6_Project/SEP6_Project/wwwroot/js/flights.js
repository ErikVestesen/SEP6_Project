window.onload = function () {
    this.loadFlights();
} 


function loadFlights() {
    var element = document.getElementById("myfirstchart");

    $.ajax({
        type: "POST",
        url: 'Home/SelectOrigin',
        success: function (result) {
            alert(result.d);
            Morris.Bar({
                element: element,
                data: [
                    { y: '2006', a: 100, b: 90 },
                    { y: '2007', a: 75, b: 65 },
                    { y: '2008', a: 50, b: 40 },
                    { y: '2009', a: 75, b: 65 },
                    { y: '2010', a: 50, b: 40 },
                    { y: '2011', a: 75, b: 65 },
                    { y: '2012', a: 100, b: 90 }
                ],
                xkey: 'y',
                ykeys: ['a', 'b'],
                labels: ['Series A', 'Series B']
            });
        },
        error: function (e) {
            $("#divResult").html("Something Wrong.");
        }
    });
}