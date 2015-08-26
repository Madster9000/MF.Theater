using System;

namespace MF.Theater.DTO
{
    public class PlayPeriodDto
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int TicketsCapacity { get; set; }

        public Guid PerfomanceId { get; set; }
    }
}