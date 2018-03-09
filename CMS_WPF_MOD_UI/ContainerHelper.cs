using DataLayer.Repositories;
using Microsoft.Practices.Unity;

namespace ChangeManagementAppModern
{
    public static class ContainerHelper
    {
        private static IUnityContainer _container;
        static ContainerHelper()
        {
            _container = new UnityContainer();
            _container.RegisterType<IChangeTypeRepository, ChangeTypeRepository>(new ContainerControlledLifetimeManager());
        }

        public static IUnityContainer Container
        {
            get { return _container; }
        }
    }
}
