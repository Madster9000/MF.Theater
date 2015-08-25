using System.Data.Entity;
using MF.Theater.DataModel;

namespace MF.Theater.Context
{
    public class TheaterContext: DbContext
    {
        public TheaterContext()
            : base("name=TheaterDbConnectionString")
        {
        }

        public DbSet<Perfomance> Perfomances { get; set; }
        public DbSet<PlayPeriod> PlayPeriods { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}