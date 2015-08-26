using System.Data.Entity;

namespace MF.Theater.Context.Factories
{
    public class TheaterContextWithoutProxiesFactory: IDbContextFactory
    {
        public DbContext CreateContext()
        {
            var context = new TheaterContext();
            context.Configuration.ProxyCreationEnabled = false;
            context.Configuration.LazyLoadingEnabled = false;

            return context;
        }
    }
}