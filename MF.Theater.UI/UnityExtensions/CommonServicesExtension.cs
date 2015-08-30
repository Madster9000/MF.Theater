using MF.Theater.Services.Common;
using Microsoft.Practices.Unity;

namespace MF.Theater.UI.UnityExtensions
{
    public class CommonServicesExtension: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IEmailSender, EmailSender>();
        }
    }
}