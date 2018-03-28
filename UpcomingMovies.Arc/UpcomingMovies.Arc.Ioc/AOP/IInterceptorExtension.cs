namespace UpcomingMovies.Arc.Ioc
{
    public interface IInterceptorExtension
    {
        void Configure();
        void DefineInterceptor(IDependencyObject dependency);
    }
}
