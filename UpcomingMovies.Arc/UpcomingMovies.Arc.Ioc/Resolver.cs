using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Resolution;

namespace UpcomingMovies.Arc.Ioc
{
   public class Resolver : IDependencyResolver
    {
        #region Fields

        private static Resolver container;
        private static IUnityContainer unityContainer;

        #endregion

        #region Properties

        public static Resolver Container
        {
            get
            {
                if (container == null)
                {
                    container = new Resolver();
                }

                return container;
            }
        }

        public static Y Get<Y>()
        {
            return Container.GetService<Y>();
        }

        public static Y Get<Y>(Type type)
        {
            return (Y)Container.GetService(type);
        }

        public static Y Get<Y>(Type type, string parameterName, object value)
        {
            return (Y)Container.GetService(type, parameterName, value);
        }

        public static Y Get<Y>(string parameterName, object value)
        {
            return Container.GetService<Y>(parameterName, value);
        }

        #endregion

        #region Methods

        public void UnityInjection(IUnityContainer unityContainer)
        {
            Resolver.unityContainer = unityContainer;
        }

        #endregion

        #region IDependencyResolver members

        public IEnumerable<DependencyObject> Registrations
        {
            get
            {
                return unityContainer.Registrations.Select(r => new DependencyObject(r.RegisteredType, r.MappedToType)).ToList();
            }
        }

        public object GetService(Type type)
        {
            return unityContainer.Resolve(type);
        }

        public object GetService(Type type, string parameterName, object value)
        {
            return unityContainer.Resolve(type, new ParameterOverride(parameterName, value));
        }

        public object GetService(Type type, string parserName, string parameterName, object value)
        {
            return unityContainer.Resolve(type, parserName, new ParameterOverride(parameterName, value));
        }

        public T GetService<T>()
        {
            try
            {
                return unityContainer.Resolve<T>();
            }
            catch
            {             
                return default(T);
            }
        }

        public T GetService<T>(string parameterName, object value)
        {
            try
            {
                return unityContainer.Resolve<T>(new ParameterOverride(parameterName, value));
            }
            catch
            {
                return default(T);
            }
        }

        public IEnumerable<T> GetServices<T>()
        {
            return unityContainer.ResolveAll<T>();
        }

        public object GetServiceByType(Type type, string parameterName, object value)
        {
            return unityContainer.Resolve(type, new ParameterOverride(parameterName, value));
        }

        public void Register(Type type)
        {
            unityContainer.RegisterType(type);
        }

        public void Register<T>()
        {
            unityContainer.RegisterType<T>();
        }

        #endregion
    }
}
