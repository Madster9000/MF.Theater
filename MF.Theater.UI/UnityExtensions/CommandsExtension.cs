using MF.Theater.Services.Commands;
using Microsoft.Practices.Unity;

namespace MF.Theater.UI.UnityExtensions
{
    public class CommandsExtension: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IPerfomanceCommands, PerfomanceCommands>();
            Container.RegisterType<ITicketCommands, TicketCommands>();
        }
    }
}