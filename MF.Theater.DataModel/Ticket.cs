using System;

namespace MF.Theater.DataModel
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }

        public Guid PlayPeriodId { get; set; }
        public virtual PlayPeriod PlayPeriod { get; set; }
    }
}