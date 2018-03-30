using UpcomingMovies.Arc.Models.Interfaces;

namespace UpcomingMovies.Arc.Views.Interfaces
{
    public interface IUpcomingMovieDetailView
    {
        IUpcomingMovie SelectedItem { get; set; }
    }
}
