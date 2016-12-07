$(".genreButton").click(function () {
    var genre = $(this).val();
    var source = "/Home/GetGenre/" + genre;
    console.log(source);
    $.ajax({
        type: "GET",
        datatype: "json",
        url: source,
        success: displayGenre
    });
});

function displayGenre(data) {
    var table = $("#genreTable"),
        thead = $('<tr><th>Art Piece</th><th>Artist</th></tr>');
    table.empty();
    thead.appendTo(table);

    data.arr.forEach(function (pas) {
        table.append(pas);
    });
}