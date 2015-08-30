function IndexPageViewModel()
{
    var self = this;
    var itemsOnPage = 2;

    //для нормального внедрения зависимостей следует использовать require.js
    var perfomancesService = PerfomancesService();
    var pagesService = PagesService();
    
    var applyPerfomances = function(perfomances)
    {
        self.Perfomances(perfomances);
    }

    var applyPerfomancesCount = function(pagesCount)
    {
        self.PerfomancesCount(pagesCount);

        var pages = pagesService.ComputePages(pagesCount, itemsOnPage);
        self.PagesArray(pages);

        perfomancesService.GetPage(1, itemsOnPage, applyPerfomances);
    }


    self.PerfomancesCount = ko.observable();
    self.ItemsOnPage = 3;

    self.PagesArray = ko.observableArray();
    self.Perfomances = ko.observableArray();

    self.ApplyPage = function(page)
    {
        perfomancesService.GetPage(page.itemIndex, itemsOnPage, applyPerfomances);
    }


    perfomancesService.GetCount(applyPerfomancesCount);
}

ko.applyBindings(new IndexPageViewModel());