using System.Data.Entity.ModelConfiguration;
using MF.Theater.DataModel;

namespace MF.Theater.Context.Mappings
{
    public class PlayPeriodMap: EntityTypeConfiguration<PlayPeriod>
    {
        public PlayPeriodMap()
        {
            HasRequired(x => x.Perfomance).WithMany(p => p.PlayPeriods).HasForeignKey(x => x.PerfomanceId);
        }
    }
}