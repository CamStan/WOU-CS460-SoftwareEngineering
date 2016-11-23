$("#request").click(function () {
    var symbol = $("#stockSymbol").val();
    console.log(symbol);
    var source = "/Home/Stocks/" + symbol;
    console.log(source);
    $.ajax({
        type: "GET",
        datatype: "json",
        url: source,
        success: displayStocks
    });
});

function displayStocks(data) {
    graph = new Dygraph(
        document.getElementById("graphdiv"),
        data.csv,
        {
            rollPeriod: 7,
            showRoller: true,
            Volume : {
                axis: 'y2'
            },
            axis: {
                y2: {
                    labelsKMB: true
                }
            },
            //ylabel: 'Primary y-axis',
            y1label: 'Secondary y-axis'
        }
        );
    //$("#graphdiv").text(data.csv);
}