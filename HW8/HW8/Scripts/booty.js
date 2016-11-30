/*
    Function linked to Home/Booty that makes an Ajax call to Home/GetBooty
    when the document is ready. On success, the retrieved Json data is sent
    to the displayBooty function to be sent back to the view
*/
$(document).ready(function () {
    var source = "/Home/GetBooty";
    $.ajax({
        type: "GET",
        datatype: "json",
        url: source,
        success: displayBooty
    });
});

/*
    Takes the Json data from the above Ajax call and displays the data to the
    Home/Booty page
*/
function displayBooty(data) {
    var table = $("#bootyTable"),
        thead = $('<tr><th>Pirate</th><th>Total Booty</th></tr>');
    thead.appendTo(table);

    data.arr.forEach(function (pb) {
        table.append(pb);
    });
}