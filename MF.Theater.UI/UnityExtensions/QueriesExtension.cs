using MF.Theater.Context.Factories;
using MF.Theater.Services.Queries;
using Microsoft.Practices.Unity;

namespace MF.Theater.UI.UnityExtensions
{
    public class QueriesExtension: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IPerfomanceQueries, PerfomanceQueries>();
            Container.RegisterType<IDbContextFactory, TheaterContextFactory>();
        }
    }
}