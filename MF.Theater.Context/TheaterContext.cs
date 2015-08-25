using System.Data.Entity;
using MF.Theater.Context.Mappings;
using MF.Theater.DataModel;

namespace MF.Theater.Context
{
    public class TheaterContext: DbContext
    {
        public TheaterContext()
            : base("name=TheaterDbConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PerfomanceMap());
            modelBuilder.Configurations.Add(new TicketMap());
            modelBuilder.Configurations.Add(new PlayPeriodMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Perfomance> Perfomances { get; set; }
        public DbSet<PlayPeriod> PlayPeriods { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}