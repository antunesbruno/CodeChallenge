using System.Collections.Generic;

namespace UpcomingMovies.Arc.Ioc
{
    public static class DependencyStart
    {
        private static bool dependencyStarted = false;

        public static bool DependencyStarted
        {
            get
            {
                return dependencyStarted;
            }

            set
            {
                dependencyStarted = value;
            }
        }

        public static void Start(IList<IDependencyObject> dependencies)
        {
            //Starts container
            var unityContainer = DependencyContainerFactory.GetContainer(dependencies);
            DependencyResolver.Container.UnityInjection(unityContainer);

            //seta o flag
            dependencyStarted = true;
        }
    }
}
