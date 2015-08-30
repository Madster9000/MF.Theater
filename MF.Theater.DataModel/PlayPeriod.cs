using System;
using System.Collections.Generic;

namespace MF.Theater.DataModel
{
    public class PlayPeriod
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int TicketsCapacity { get; set; }

        public Guid PerfomanceId { get; set; }
        public virtual Perfomance Perfomance { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }

        public PlayPeriod()
        {
            Tickets = new HashSet<Ticket>();
        }
    }
}