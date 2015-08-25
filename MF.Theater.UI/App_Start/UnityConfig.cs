using System.Web.Mvc;
using MF.Theater.UI.UnityExtensions;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace MF.Theater.UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.AddNewExtension<QueriesExtension>();
            container.AddNewExtension<AuthenticationExtension>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }

}