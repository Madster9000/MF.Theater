function CreatePerfomanceViewModel() {
    var self = this;

    //для нормального внедрения зависимостей следует использовать require.js
    var perfomancesService = PerfomancesService();
    var messagesService = MessagesService.GetInstance();

    var createCallback = function(data) {
        alert(data);
    }

    self.PerfomanceViewModel = new PerfomanceViewModel();
    


    self.CreatePerfomance = function()
    {
        var plainVm = ko.toJS(self.PerfomanceViewModel);
        perfomancesService.Create(plainVm, createCallback);

        messagesService.PerfomanceCreatedChannel.Publish();
    }

    self.AddPeriod = function()
    {
        self.PerfomanceViewModel.PlayPeriods.push(new PlayPeriodViewModel());
    }
}

ko.applyBindings(new CreatePerfomanceViewModel(), document.getElementById("CreatePerfomanceModal"));