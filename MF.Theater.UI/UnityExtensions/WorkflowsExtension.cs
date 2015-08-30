using MF.Theater.Services.Commands;
using MF.Theater.Services.Workflows;
using Microsoft.Practices.Unity;

namespace MF.Theater.UI.UnityExtensions
{
    public class WorkflowsExtension: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<SendEmailWorkflow>();
            Container.RegisterType<IPerfomanceWorkflow, UpdatePerfomanceWorkflow>
                (
                    new InjectionConstructor
                        (
                        Container.Resolve<IPerfomanceCommands>(),
                        Container.Resolve<SendEmailWorkflow>()
                        )
                );
        }
    }
}