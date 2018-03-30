using System.Collections.Generic;
using UpcomingMovies.Arc.Ioc;
using Xamarin.Forms;

namespace UpcomingMovies.Arc.Base
{
    public abstract class BaseApplication : Application
    {
        #region Properties       

        public static BaseApplication Instance { get; private set; }

        #endregion

        #region Constructor        

        public BaseApplication()
        {
            Instance = this;
            InitializeContainer();
            InitializeApplication();
        }

        #endregion

        #region Abstract Methods        

        public abstract void InitializeApplication();

        protected abstract List<IDependencyObject> CreateDependencies();

        #endregion

        #region Methods        

        /// <summary>
        /// Initialize IOC container
        /// </summary>
        public void InitializeContainer()
        {
            var dependencies = CreateDependencies();
            var unityContainer = DependencyContainerFactory.GetContainer(dependencies);
            Resolver.Container.UnityInjection(unityContainer);
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        public virtual void ResetIdleTimer()
        {

        }

        #endregion
    }
}
