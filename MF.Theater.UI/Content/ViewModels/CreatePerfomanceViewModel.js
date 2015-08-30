function PerfomanceViewModel()
{
    var self = this;
    self.Name = ko.observable();
    self.Description = ko.observable();
    self.PlayPeriods = ko.observableArray();
}

function CreatePerfomanceViewModel() {
    var self = this;

    //для нормального внедрения зависимостей следует использовать require.js
    var perfomancesService = PerfomancesService();
    var messagesService = MessagesService.GetInstance();

    self.PerfomanceViewModel = new PerfomanceViewModel();
    

    self.CreatePerfomance = function()
    {
        var plainVm = ko.toJS(self.PerfomanceViewModel);
        perfomancesService.Create(plainVm);

        messagesService.PerfomanceCreatedChannel.Publish();
    }

    self.AddPeriod = function()
    {
        self.PerfomanceViewModel.PlayPeriods.push(new PlayPeriodViewModel());
    }
}

ko.applyBindings(new CreatePerfomanceViewModel(), document.getElementById("CreatePerfomanceModal"));