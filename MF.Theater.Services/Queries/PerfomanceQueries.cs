using System.Collections.Generic;
using System.Linq;
using MF.Theater.Context.Factories;
using MF.Theater.DataModel;

namespace MF.Theater.Services.Queries
{
    public class PerfomanceQueries: IPerfomanceQueries
    {
        private readonly IDbContextFactory mDbContextFactory;

        public PerfomanceQueries(IDbContextFactory dbContextFactory)
        {
            mDbContextFactory = dbContextFactory;
        }

        public ICollection<Perfomance> SelectAll()
        {
            using (var context = mDbContextFactory.CreateContext())
            {
                return context.Set<Perfomance>().ToList();
            }
        }
    }
}