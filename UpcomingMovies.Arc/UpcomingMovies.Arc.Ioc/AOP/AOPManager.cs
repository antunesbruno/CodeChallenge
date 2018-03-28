

namespace UpcomingMovies.Arc.Ioc
{
    public class AOPManager
    {
        private static IInterceptorExtension _interceptor;

        public static IInterceptorExtension Interceptor 
        {
            get { return _interceptor; }
            set { _interceptor = _interceptor ?? value; }
        }
    }
}
