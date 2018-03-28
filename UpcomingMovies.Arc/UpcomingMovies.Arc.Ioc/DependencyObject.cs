
using System;

namespace UpcomingMovies.Arc.Ioc
{
    public class DependencyObject : IDependencyObject
    {
        #region Properties

        public Type InterfaceType { get; private set; }
        public Type ClassType { get; private set; }
        public LifetimeType Lifetime { get; private set; }
        public string Name { get; private set; }
        public object[] Parameters { get; private set; }
        public string ParserName { get; set; }
        public object Instance { get; set; }
        public bool IsIntercepted { get; private set; }

        #endregion

        #region Constructor

        public DependencyObject(Type interfaceType, object instance, bool isIntercepted = false)
        {
            InterfaceType = interfaceType;
            Instance = instance;
            IsIntercepted = isIntercepted;
        }

        public DependencyObject(Type interfaceType, Type classType, LifetimeType lifetimeType = LifetimeType.ContainerController, bool isIntercepted = false)
        {
            InterfaceType = interfaceType;
            ClassType = classType;
            Lifetime = lifetimeType;
            IsIntercepted = isIntercepted;
        }

        public DependencyObject(Type interfaceType, Type classType, LifetimeType lifetimeType, string name, bool isIntercepted = false)
        {
            InterfaceType = interfaceType;
            ClassType = classType;
            Lifetime = lifetimeType;
            Name = name;
            IsIntercepted = isIntercepted;
        }

        public DependencyObject(Type interfaceType, Type classType, LifetimeType lifetimeType, string name, string parserName = null, bool isIntercepted = false, params object[] parameters)
        {
            InterfaceType = interfaceType;
            ClassType = classType;
            Lifetime = lifetimeType;
            Name = name;
            ParserName = parserName;
            IsIntercepted = isIntercepted;
            Parameters = parameters ?? new object[] { };
        }

        #endregion
    }
}
