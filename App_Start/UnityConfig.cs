using GitHubApplication.Interface;
using GitHubApplication.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace GitHubApplication
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IClientWebService, ClientWebService>();           
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}