/*
    Watches for when the 'Request' button is clicked and upon a click,
    gets the value in the stockSymbol text input and makes an AJAX call
    to the Home/Stocks JsonResult method with the input value as the
    parameter. The JsonResult data from the AJAX call is then sent to
    the displayStocks function.
*/
$("#request").click(function () {
    var symbol = $("#stockSymbol").val();
    var source = "/Home/Stocks/" + symbol;
    $.ajax({
        type: "GET",
        datatype: "json",
        url: source,
        success: displayStocks
    });
});

// Variable to hold a dygraph object
var graph;

/*
    Takes the Json object from the above AJAX call and, if the the above
    call resulted in an invalid result, displays the error. Otherwise, this
    function takes the data from the Json object and builds a dygraph using
    dygraph-combined-dev.js
*/
function displayStocks(data) {
    console.log("Error: " + data.error);
    $("#graphdiv").empty();
    var eb = $("#error-block");

    if (data.error == 0) { // no error
        $("#graphOutput").removeClass("hidden");
        eb.addClass("hidden");

        // create a new Dygraph
        graph = new Dygraph(
            document.getElementById("graphdiv"), // where to put the graph
            data.csv, // the data to use in the graph
            {
                rollPeriod: 7,
                showRoller: true,
                title: data.title,
                xlabel: 'Date',
                ylabel: 'Open, High, Low, Close, Adj Close',
                y2label: 'Volume',
                series: { // split Volume values into a second y-axis
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
    else { // Json call failed and resulted in a bad .csv file
        $("#graphOutput").addClass("hidden");
        eb.removeClass("hidden");
        eb.text(data.error);
    }
}

/*
    Triggers the visibility of the respective series in the dygraph based on
    if their checkbox is checked or not
*/
function change(el) {
    graph.setVisibility(parseInt(el.id), el.checked);
}

/*
    Watches for when the 'Define' button is clicked and, upon a click, makes an
    AJAX call to the Home/Definition JsonResult method using the selected word
    from the 'word' dropdownlist as a parameter. The JsonResult data is then sent
    to the defineWord function.
*/
$("#define").click(function () {
    var word = $('#word').val();
    var source = "/Home/Definition/" + word;
    $.ajax({
        type: "GET",
        datatype: "json",
        url: source,
        success: defineWord
    });
});

/*
    Takes the JSON object from the above AJAX call and displays the word and its
    definition in the 'definition' div.
*/
function defineWord(data) {
    $("#definition").text(data.word + ": " + data.def);
    $("#definition").removeClass("hidden");
}