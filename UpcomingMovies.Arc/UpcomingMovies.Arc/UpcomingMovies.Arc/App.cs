using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Arc.ApiClient;
using UpcomingMovies.Arc.Base;
using UpcomingMovies.Arc.Ioc;
using UpcomingMovies.Arc.Views;

namespace UpcomingMovies.Arc
{
    public partial class App : BaseApplication
    {
        #region Fields

        private List<IDependencyObject> dependencies = new List<IDependencyObject>();

        #endregion

        public App() : base()
        {            
        }

        public override void InitializeApplication()
        {
            //var api = Resolver.Get<IApiClientHttp>();
            //api.SetApiClientHttp("https://api.themoviedb.org/3/movie/upcoming?api_key=1f54bd990f1cdfb230adb312546d765d&language=en-US&page=1");
            //var x = api.GetAsync<List<string>>("");

            //TODO: create a splash screen
            MainPage = new ItemsPage();
        }

        protected override List<IDependencyObject> CreateDependencies()
        {
            Inject<IApiClientHttp, ApiClientHttp>(LifetimeType.Transient);

            return dependencies;
        }

        #region Private Injection Methods

        private void Inject<T>(T instance)
        {
            dependencies.Add(new DependencyObject(typeof(T), instance));
        }

        protected virtual void Inject<T1, T2>(LifetimeType lifetimeType = LifetimeType.ContainerController, params object[] constructorParameters)
            where T2 : class, T1, new()
        {
            dependencies.Add(new DependencyObject(typeof(T1), typeof(T2), lifetimeType, null, null, false, constructorParameters));
        }

        protected virtual void Inject<T1, T2, T3>(LifetimeType lifetimeType = LifetimeType.ContainerController, params object[] constructorParameters)
            where T3 : class, T1, T2, new()
        {
            Inject<T1, T3>(lifetimeType, constructorParameters);
            Inject<T2, T3>(lifetimeType, constructorParameters);
        }

        protected virtual void Inject<T1, T2, T3, T4>(LifetimeType lifetimeType = LifetimeType.ContainerController, params object[] constructorParameters)
            where T4 : class, T1, T2, T3, new()
        {
            Inject<T1, T4>(lifetimeType, constructorParameters);
            Inject<T2, T4>(lifetimeType, constructorParameters);
            Inject<T3, T4>(lifetimeType, constructorParameters);
        }

        #endregion

    }
}
