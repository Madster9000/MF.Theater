var PerfomancesService = function()
{
    var service =
        {
            GetCount: function(parameters, callback)
            {
                var link = "/perfomances/count";

                link += "?sd=" + moment(parameters.StartDate).format("YYYY-MM-DDTHH:mm");
                link += "&ed=" + moment(parameters.EndDate).format("YYYY-MM-DDTHH:mm");
                link += "&n=" + parameters.Name;

                $.getJSON(link, function (data)
                {
                    callback(data);
                });
            },
            GetPage: function(parameters, callback)
            {
                console.log(parameters);
                var link = "/perfomances/selectpage?p=" + parameters.Page + "&r=" + parameters.Records;

                link += "&sd=" + moment(parameters.StartDate).format("YYYY-MM-DDTHH:mm");
                link += "&ed=" + moment(parameters.EndDate).format("YYYY-MM-DDTHH:mm");
                link += "&n=" + parameters.Name;

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
            },
            Update: function (perfomanceViewModel) {
                console.log(perfomanceViewModel);
                var link = "/perfomances/update";
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