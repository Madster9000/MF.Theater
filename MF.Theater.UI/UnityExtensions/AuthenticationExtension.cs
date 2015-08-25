using MF.Theater.UI.Controllers;
using Microsoft.Practices.Unity;

namespace MF.Theater.UI.UnityExtensions
{
    public class AuthenticationExtension: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<AccountController>(new InjectionConstructor());
        }
    }
}