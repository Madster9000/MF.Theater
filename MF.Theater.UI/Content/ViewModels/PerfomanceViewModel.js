function PerfomanceViewModel() {
    var self = this;
    self.Name = ko.observable();
    self.Description = ko.observable();
    self.PlayPeriods = ko.observableArray();
}