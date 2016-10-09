/* 
    Javascript for the 3D Printing Calculator. The use will select the 3D printer of their choice,
    input the height of the object to be printed, and select the unit of measure for the desired
    height. Upon pressing "Calculate," given there are no errors, the calculator will output in a
    table the number of layers it will take the selected printer to print that height in the
    available resolution settings for that printer.
*/

/*global $, jQuery, alert*/

/*
    Array to hold the three 3D printer objects, each of which have an id for identification, a
    name for setting to the table name, and an array of available printing resolutions. The fourth
    object is if the user doesn't know the printer they are wanting to use, they can select
    "Unknown" to see all available printing resolutions.
*/
var printerSpecs = [{
    id: "cube",
    name: "CubePro",
    microns: [70, 200, 300]
}, {
    id: "makerbot",
    name: "Makerbot Replicator 2",
    microns: [100, 200, 300]
}, {
    id: "ultimaker",
    name: "Ultimaker 2",
    microns: [20, 60, 150, 200, 400, 600]
}, {
    id: "unknown",
    name: "All Printer Options",
    microns: [20, 60, 70, 150, 200, 300, 400, 600]
}];

/*
    Converts the input centimeter value to microns (micrometers)
*/
function cm_to_microns(value) {
    "use strict";
    return value * 10000;
}

/*
    Converts the input inches value to microns (micrometers)
*/
function inches_to_microns(value) {
    "use strict";
    return cm_to_microns(value * 2.54);
}

/*
    Calculates the number of layers needed to print the input height value 
    in the input unit of measure using the input resolution thickness.
*/
function calculateLayers(value, thickness, unit) {
    "use strict";
    if (unit === "in") {
        return Math.ceil(inches_to_microns(value) / thickness);
    } else {
        return Math.ceil(cm_to_microns(value) / thickness);
    }
}

/*
    Builds the output table after the user presses the "Calculate" button. The left
    column of the table is the resolution in microns and the right column is the 
    number of layers needed to print the input height for each resolution.
*/
function createCalcTable(name, value, unit) {
    "use strict";
    var printerObject = $.grep(printerSpecs, function (obj) { // gets the desired printer from the printerSpecs array
            return obj.id === name;
        }),
        calcTable = $('<table>', {
            "class": 'table table-striped table-bordered'
        }),
        tName = $('<caption>').text(printerObject[0].name),
        tColumns = $('<thead><tr><th>Resolution<small> (<em>in microns</em>)</small></th><th>Layers</th></tr></thead>');
    tName.appendTo(calcTable);
    tColumns.appendTo(calcTable);
    printerObject[0].microns.forEach(function (res) { // loop to calculate and add each resolution
        var layers = calculateLayers(value, res, unit),
            trow = $('<tr>'),
            tres = $('<td>').text(res),
            tlayers = $('<td>').text(layers);
        tres.appendTo(trow);
        tlayers.appendTo(trow);
        trow.appendTo(calcTable);
    });
    return calcTable;
}

/* 
    Checks to see that the user has selected a printer option. If not, displays error message and encircles
    printer selection box in red.
*/
function validatePrinter(printerObject, helpBlock) {
    "use strict";
    var pSel = $('#printer-selector');
    if (printerObject === "choose") { // error if first option is selected
        pSel.addClass("has-error has-feedback");
        helpBlock.text("Please select a printer.");
        helpBlock.removeClass("hidden");
        $('#calcResults').empty();
        return false;
    } else {
        pSel.removeClass("has-error has-feedback");
        helpBlock.addClass("hidden");
        return true;
    }
}

/* 
    Checks to see that the user has input a proper height value. If not, displays error message and encircles
    height input area in red with an 'x' error.
*/
function validateHeight(heightValue, helpBlock) {
    "use strict";
    var hInput = $('#height-input'),
        error = $('span.glyphicon');
    if (heightValue === "" || isNaN(heightValue)) { // error if empty or not a number
        hInput.addClass("has-error has-feedback");
        helpBlock.text("Please enter a valid height.");
        helpBlock.removeClass("hidden");
        error.removeClass("hidden");
        $('#calcResults').empty();
        return false;
    } else {
        hInput.removeClass("has-error has-feedback");
        helpBlock.addClass("hidden");
        error.addClass("hidden");
        return true;
    }
}

/*
    Submit function for the "Calculate" button. Validates the printer selection option and height input.
    If validations pass, the table is created based on the input printer, height, and unit of measure.
    Then the printer selector is reset and the height value emptied.
*/
$("#calcLayers").submit(function (event) {
    "use strict";
    event.preventDefault();
    var printerName = $('#printers').val(),
        helpBlock = $('span.help-block'),
        heightValue = $('#height').val().trim(),
        unit = $('input[name=radio-unit]:checked').val();
    if (validatePrinter(printerName, helpBlock) && validateHeight(heightValue, helpBlock)) {
        $('#calcResults').empty();
        $('#calcResults').append(createCalcTable(printerName, heightValue, unit));
        $('#printers').prop('selectedIndex', 0);
        $('#height').val("");
    }
});