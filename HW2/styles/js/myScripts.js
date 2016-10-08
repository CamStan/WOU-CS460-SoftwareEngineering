/*global $, jQuery, alert*/

function validatePrinter(printerObject, helpBlock) {
    "use strict";
    var pSel = $('#printer-selector');
    if (printerObject === "choose") {
        pSel.addClass("has-error has-feedback");
        helpBlock.text("Please select a printer");
        helpBlock.removeClass("hidden");
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
        helpBlock.text("Please enter a valid height");
        helpBlock.removeClass("hidden");
        error.removeClass("hidden");
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
    var printerObject = $('#printers').val(),
        helpBlock = $('span.help-block'),
        heightValue = $('#height').val().trim();
    if (validatePrinter(printerObject, helpBlock) && validateHeight(heightValue, helpBlock)) {
        alert(printerObject + heightValue);
    }
    return false;
});