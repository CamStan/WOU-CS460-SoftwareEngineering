$(document).ready(function () {
    var source = "/Home/GetBooty";
    $.ajax({
        type: "GET",
        datatype: "json",
        url: source,
        success: displayBooty
    });
});

function displayBooty(data) {
    var table = $("#bootyTable"),
        thead = $('<tr><th>Pirate</th><th>Total Booty</th></tr>');
    thead.appendTo(table);

    data.arr.forEach(function (pb) {
        table.append(pb);
    });
}