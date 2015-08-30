var PlayPeriodViewModel = function () {
    var self = this;

    self.StartDate = ko.observable();
    self.EndDate = ko.observable();
    self.TicketsCapacity = ko.observable(0);
}