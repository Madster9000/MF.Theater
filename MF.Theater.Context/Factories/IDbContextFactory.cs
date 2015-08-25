using System.Data.Entity;

namespace MF.Theater.Context.Factories
{
    public interface IDbContextFactory
    {
        DbContext CreateContext();
    }
}