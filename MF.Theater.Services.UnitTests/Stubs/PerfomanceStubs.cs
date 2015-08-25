using System.Data.Entity;
using System.Linq;
using MF.Theater.DataModel;
using Moq;

namespace MF.Theater.Services.UnitTests.Stubs
{
    public static class PerfomanceStubs
    {
        public static DbSet<Perfomance> CreateDbSet(IQueryable<Perfomance> perfomances)
        {
            var mockSet = new Mock<DbSet<Perfomance>>();
            mockSet.As<IQueryable<Perfomance>>().Setup(m => m.Provider).Returns(perfomances.Provider);
            mockSet.As<IQueryable<Perfomance>>().Setup(m => m.Expression).Returns(perfomances.Expression);
            mockSet.As<IQueryable<Perfomance>>().Setup(m => m.ElementType).Returns(perfomances.ElementType);
            mockSet.As<IQueryable<Perfomance>>().Setup(m => m.GetEnumerator()).Returns(perfomances.GetEnumerator());

            return mockSet.Object;
        }
    }
}