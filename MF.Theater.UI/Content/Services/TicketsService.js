var TicketsService = function () {
    var service =
        {
            Create: function (playPeriod, callback)
            {
                var link = "/tickets/create";
                $.ajax({
                    url: link,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(playPeriod)
                }).done(callback);
            }
        }

    return service;
}