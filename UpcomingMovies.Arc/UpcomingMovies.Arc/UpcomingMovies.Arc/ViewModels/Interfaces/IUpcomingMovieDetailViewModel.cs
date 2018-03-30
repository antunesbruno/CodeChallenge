using UpcomingMovies.Arc.Models.Interfaces;

namespace UpcomingMovies.Arc.ViewModels.Interfaces
{
    public interface IUpcomingMovieDetailViewModel
    {
        IUpcomingMovie SelectedItem { get; set; }
    }
}
