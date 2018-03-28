
using System;

namespace UpcomingMovies.Arc.Ioc
{
    public interface IDependencyObject
    {
        Type InterfaceType { get; }
        Type ClassType     { get; }
        LifetimeType Lifetime { get; }
		object[] Parameters { get; }
        string ParserName { get; }
        object Instance { get; }
        bool IsIntercepted { get;  }
    }
}
