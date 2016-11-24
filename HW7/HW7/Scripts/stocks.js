﻿$("#request").click(function () {
    var symbol = $("#stockSymbol").val();
    var source = "/Home/Stocks/" + symbol;
    $.ajax({
        type: "GET",
        datatype: "json",
        url: source,
        success: displayStocks
    });
});

var graph;

function displayStocks(data) {
    console.log("Error: " + data.error);
    $("#graphdiv").empty();
    var go = $("graphOutput");
    var eb = $("#error-block");
    if (data.error == 0) {
        $("#graphOutput").removeClass("hidden");
        eb.addClass("hidden");
        graph = new Dygraph(
            document.getElementById("graphdiv"),
            data.csv,
            {
                rollPeriod: 7,
                showRoller: true,
                title: data.title,
                xlabel: 'Date',
                ylabel: 'Open, High, Low, Close, Adj Close',
                y2label: 'Volume',
                series: {
                    Volume: {
                        axis: 'y2'
                    }
                },
                axes: {
                    y2: {
                        labelsKMB: true,
                        drawGrid: true,
                        independentTicks: true
                    }
                }
            }
            );
    }
    else {
        $("#graphOutput").addClass("hidden");
        eb.removeClass("hidden");
        eb.text(data.error);
    }
}

function change(el) {
    graph.setVisibility(parseInt(el.id), el.checked);
}

//$("#request").click(function () {
//    //var symbol = $("#stockSymbol").val();
//    //console.log(symbol);
//    var source = "/Home/Symbols/";
//    console.log(source);
//    $.ajax({
//        type: "GET",
//        datatype: "json",
//        url: source,
//        success: displaySymbol
//    });
//});

//function displaySymbol(data) {
//    console.log(data);
//    $("#test").text(data.txt);
//}