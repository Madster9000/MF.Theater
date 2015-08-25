using System.Data.Entity.ModelConfiguration;
using MF.Theater.DataModel;

namespace MF.Theater.Context.Mappings
{
    public class TicketMap : EntityTypeConfiguration<Ticket>
    {
        public TicketMap()
        {
            HasRequired(x => x.PlayPeriod).WithMany(pp => pp.Tickets).HasForeignKey(x => x.PlayPeriodId);
            Property(x => x.UserEmail).IsRequired();
        }
    }
}