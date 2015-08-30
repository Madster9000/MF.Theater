function IndexPageViewModel()
{
    var self = this;
    var itemsOnPage = 2;

    //для нормального внедрения зависимостей следует использовать require.js
    var perfomancesService = PerfomancesService();
    var pagesService = PagesService();

    var applyPerfomancesCount = function (pagesCount)
    {
        console.log(pagesCount);
        self.PerfomancesCount(pagesCount);

        var pages = pagesService.ComputePages(pagesCount, itemsOnPage);
        self.PagesArray(pages);
    }
    
    var applyPerfomances = function(perfomances)
    {
        self.Perfomances(perfomances);
    }

    

    var initialize = function () {
        

        self.PerfomancesFilterParameters.Page = 1;
        self.PerfomancesFilterParameters.Records = itemsOnPage;

        var parameters = ko.toJS(self.PerfomancesFilterParameters);

        perfomancesService.GetCount(parameters, applyPerfomancesCount);
        perfomancesService.GetPage(parameters, applyPerfomances);
        
    }


    self.PerfomancesCount = ko.observable();
    self.ItemsOnPage = 3;

    self.PagesArray = ko.observableArray();
    self.Perfomances = ko.observableArray();
    self.PerfomancesFilterParameters = new PerfomancesFilterParameters();

    self.ApplyPage = function(page)
    {
        self.PerfomancesFilterParameters.Page = page.itemIndex;
        self.PerfomancesFilterParameters.Records = itemsOnPage;

        var parameters = ko.toJS(self.PerfomancesFilterParameters);

        perfomancesService.GetPage(parameters, applyPerfomances);
    }
    self.ApplyFilters = function()
    {
        initialize();
    }


    //perfomancesService.GetCount(applyPerfomancesCount);
    initialize();
}

ko.applyBindings(new IndexPageViewModel());