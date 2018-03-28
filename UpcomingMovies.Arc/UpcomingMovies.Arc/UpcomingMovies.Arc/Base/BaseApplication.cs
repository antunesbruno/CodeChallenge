using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Arc.Ioc;
using Xamarin.Forms;

namespace UpcomingMovies.Arc.Base
{
    public abstract class BaseApplication : Application
    {
        public static BaseApplication Instance { get; private set; }

        public BaseApplication()
        {
            Instance = this;
            InitializeContainer();
            InitializeApplication();
        }

        public abstract void InitializeApplication();

        protected abstract List<IDependencyObject> CreateDependencies();

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
    }
}
