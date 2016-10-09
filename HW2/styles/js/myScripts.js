/*global $, jQuery, alert*/

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

function cm_to_microns(value) {
    "use strict";
    return value * 10000;
}

function inches_to_microns(value) {
    "use strict";
    return cm_to_microns(value * 2.54);
}

function calculateLayers(value, thickness, unit) {
    "use strict";
    if (unit === "in") {
        return Math.ceil(inches_to_microns(value) / thickness);
    } else {
        return Math.ceil(cm_to_microns(value) / thickness);
    }
}

function createCalcTable(name, value, unit) {
    "use strict";
    var printerObject = $.grep(printerSpecs, function (obj) {
            return obj.id === name;
        }),
        calcTable = $('<table>', {
            "class": 'table table-striped table-bordered'
        }),
        tName = $('<caption>').text(printerObject[0].name),
        tColumns = $('<thead><tr><th>Resolution<small> (<em>in microns</em>)</small></th><th>Layers</th></tr></thead>');
    tName.appendTo(calcTable);
    tColumns.appendTo(calcTable);
    printerObject[0].microns.forEach(function (res) {
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

function validatePrinter(printerObject, helpBlock) {
    "use strict";
    var pSel = $('#printer-selector');
    if (printerObject === "choose") {
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

function validateHeight(heightValue, helpBlock) {
    "use strict";
    var hInput = $('#height-input'),
        error = $('span.glyphicon');
    if (heightValue === "" || isNaN(heightValue)) {
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