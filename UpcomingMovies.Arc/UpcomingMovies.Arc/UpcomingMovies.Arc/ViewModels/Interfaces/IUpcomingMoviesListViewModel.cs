using System.Threading.Tasks;
using UpcomingMovies.Arc.Models.Helpers;
using UpcomingMovies.Arc.Models.Interfaces;

namespace UpcomingMovies.Arc.ViewModels.Interfaces
{
    public interface IUpcomingMoviesListViewModel
    {
        string SearchText { get; set; }
        ObservableRangeCollection<IUpcomingMovie> Items { get; set; }
        Task LoadListItems();
        Task LoadLazyList(IUpcomingMovie item);
        Task ExecuteSearchCommand();
    }
}
