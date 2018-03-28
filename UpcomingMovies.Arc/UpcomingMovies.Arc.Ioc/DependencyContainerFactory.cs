using System.Collections.Generic;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Registration;

namespace UpcomingMovies.Arc.Ioc
{

    public static class DependencyContainerFactory
    {
        #region Fields

        private static IUnityContainer _container;
        
        #endregion

        #region Properties

        public static IUnityContainer Container
        {
            get
            {
                if (_container == null)
                    _container = new UnityContainer();

                return _container;
            }
        } 

        #endregion

        #region Methods

        public static IUnityContainer GetContainer(IList<IDependencyObject> dependencies)
        {
            var container = Container;

            foreach (var dependency in dependencies)
            {
                var lifetime = dependency.Lifetime == LifetimeType.Transient ? null : new ContainerControlledLifetimeManager();

                if (lifetime != null)
                {
                    if (dependency.Parameters == null)
                    {
                        if (!string.IsNullOrEmpty(dependency.ParserName))
                        {
                            if (dependency.IsIntercepted)
                                AOPManager.Interceptor.DefineInterceptor(dependency);
                            else
                                container.RegisterType(dependency.InterfaceType, dependency.ClassType, dependency.ParserName, lifetime, null);
                        }
                        else
                        {
                            if (dependency.IsIntercepted)
                                AOPManager.Interceptor.DefineInterceptor(dependency);
                            else
                                container.RegisterType(dependency.InterfaceType, dependency.ClassType, lifetime);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dependency.ParserName))
                        {
                            if (dependency.IsIntercepted)
                                AOPManager.Interceptor.DefineInterceptor(dependency);
                            else
                                container.RegisterType(dependency.InterfaceType, dependency.ClassType, dependency.ParserName, lifetime, new InjectionMember[] { new InjectionConstructor(dependency.Parameters) });
                        }
                        else
                        {
                            if (dependency.IsIntercepted)
                                AOPManager.Interceptor.DefineInterceptor(dependency);
                            else
                                container.RegisterType(dependency.InterfaceType, dependency.ClassType, lifetime, new InjectionConstructor(dependency.Parameters));
                        }
                    }
                }
                else
                {
                    if (dependency.Instance != null)
                    {
                        if (dependency.IsIntercepted)
                            AOPManager.Interceptor.DefineInterceptor(dependency);
                        else
                            container.RegisterInstance(dependency.InterfaceType, dependency.Instance);
                    }
                    else if (dependency.Parameters == null)
                    {
                        if (!string.IsNullOrEmpty(dependency.ParserName))
                        {
                            if (dependency.IsIntercepted)
                                AOPManager.Interceptor.DefineInterceptor(dependency);
                            else
                                container.RegisterType(dependency.InterfaceType, dependency.ClassType, dependency.ParserName, null);
                        }
                        else
                        {
                            if (dependency.IsIntercepted)
                                AOPManager.Interceptor.DefineInterceptor(dependency);
                            else
                                container.RegisterType(dependency.InterfaceType, dependency.ClassType);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(dependency.ParserName))
                        {
                            if (dependency.IsIntercepted)
                                AOPManager.Interceptor.DefineInterceptor(dependency);
                            else
                                container.RegisterType(dependency.InterfaceType, dependency.ClassType, dependency.ParserName, new InjectionConstructor(dependency.Parameters));
                        }
                        else
                        {
                            if (dependency.IsIntercepted)
                                AOPManager.Interceptor.DefineInterceptor(dependency);
                            else
                                container.RegisterType(dependency.InterfaceType, dependency.ClassType, new InjectionConstructor(dependency.Parameters));
                        }
                    }
                }
            }

            return container;
        } 
        #endregion
    }
}
