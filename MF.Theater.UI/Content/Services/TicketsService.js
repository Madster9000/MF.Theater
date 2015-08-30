var TicketsService = function () {
    var service =
        {
            Create: function (playPeriod)
            {
                var link = "/tickets/create";
                $.ajax({
                    url: link,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(playPeriod)
                });
                //$.post(link, playPeriod);
            }
        }

    return service;
}