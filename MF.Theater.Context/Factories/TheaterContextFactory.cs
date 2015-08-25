using System.Data.Entity;

namespace MF.Theater.Context.Factories
{
    public class TheaterContextFactory: IDbContextFactory
    {
        public DbContext CreateContext()
        {
            return new TheaterContext();
        }
    }
}