

using System.ComponentModel;


namespace UpcomingMovies.Arc.Ioc
{
    public interface IDispatchPropertyChangedEvent
    {
        event PropertyChangedEventHandler DispatcherPropertyChanged;
        void DispatchPropertyChangedEvent(string propertyName);
    }
}
