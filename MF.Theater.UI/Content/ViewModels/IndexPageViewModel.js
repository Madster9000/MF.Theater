function PerfomancesFilterParameters()
{
    var self = this;

    self.StartDate = ko.observable(new Date(2000,1,1,0,0));
    self.EndDate = ko.observable(new Date(2020, 1, 1, 0, 0));
    self.Name = ko.observable("");
    self.Page = 0;
    self.Records = 0;
}
function IndexPageViewModel()
{
    var self = this;
    var itemsOnPage = 2;

    //для нормального внедрения зависимостей следует использовать require.js
    var perfomancesService = PerfomancesService();
    var pagesService = PagesService();

    var applyPerfomancesCount = function (pagesCount) {
        self.PerfomancesCount(pagesCount);

        var pages = pagesService.ComputePages(pagesCount, itemsOnPage);
        self.PagesArray(pages);

        //self.PerfomancesFilterParameters.Page = 1;
        //self.PerfomancesFilterParameters.Records = itemsOnPage;

        //var parameters = ko.toJS(self.PerfomancesFilterParameters);
        //perfomancesService.GetPage(parameters, applyPerfomances);
    }
    
    var applyPerfomances = function(perfomances)
    {
        self.Perfomances(perfomances);

        applyPerfomancesCount(perfomances.length);
    }

    

    var initialize = function () {
        perfomancesService.GetCount(applyPerfomancesCount);

        self.PerfomancesFilterParameters.Page = 1;
        self.PerfomancesFilterParameters.Records = itemsOnPage;

        var parameters = ko.toJS(self.PerfomancesFilterParameters);
        perfomancesService.GetPage(parameters, applyPerfomances);
        
    }


    self.PerfomancesCount = ko.observable();
    self.ItemsOnPage = 3;

    self.PagesArray = ko.observableArray();
    self.Perfomances = ko.observableArray();
    self.PerfomancesFilterParameters = new PerfomancesFilterParameters();

    self.ApplyPage = function(page)
    {
        self.PerfomancesFilterParameters.Page = page;
        self.PerfomancesFilterParameters.Records = itemsOnPage;

        var parameters = ko.toJS(self.PerfomancesFilterParameters);

        perfomancesService.GetPage(parameters, applyPerfomances);
    }


    //perfomancesService.GetCount(applyPerfomancesCount);
    initialize();
}

ko.applyBindings(new IndexPageViewModel());