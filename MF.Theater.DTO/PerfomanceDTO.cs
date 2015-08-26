using System;
using System.Collections.Generic;

namespace MF.Theater.DTO
{
    public class PerfomanceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<PlayPeriodDto> PlayPeriods { get; set; }
    }
}