var PerfomancesService = function()
{
    var service =
        {
            GetCount: function(callback)
            {
                $.getJSON("/perfomances/count", function (data)
                {
                    callback(data);
                });
            },
            GetPage: function(pageNumber, itemsOnPage, callback)
            {
                var link = "/perfomances/selectpage?p=" + pageNumber + "&r=" + itemsOnPage;
                $.getJSON(link, function (data)
                {
                    callback(data);
                });
            },
            Create: function(perfomanceViewModel)
            {
                console.log(perfomanceViewModel);
                var link = "/perfomances/create";
                $.ajax({
                    url: link,
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify(perfomanceViewModel)
                });
                //$.post(link, perfomanceViewModel, null, "json");
            }
        }

    return service;
}