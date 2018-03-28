
using System.Collections.Generic;

namespace UpcomingMovies.Arc.Ioc
{
    public interface IDependencyContainerService
    {
        void ContainerStart();
        IList<IDependencyObject> SetDependencies();
    }
}
