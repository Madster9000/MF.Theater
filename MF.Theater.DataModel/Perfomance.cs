using System;
using System.Collections.Generic;

namespace MF.Theater.DataModel
{
    public class Perfomance
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PlayPeriod> PlayPeriods { get; set; }
 
    }
}