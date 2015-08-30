function PerfomancesFilterParameters() {
    var self = this;

    self.StartDate = ko.observable(new Date(2000, 1, 1, 0, 0));
    self.EndDate = ko.observable(new Date(2020, 1, 1, 0, 0));
    self.Name = ko.observable("");
    self.Page = 0;
    self.Records = 0;
}