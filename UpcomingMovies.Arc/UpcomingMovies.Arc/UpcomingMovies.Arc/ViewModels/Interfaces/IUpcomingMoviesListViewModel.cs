using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Arc.Models;
using UpcomingMovies.Arc.Models.Helpers;
using UpcomingMovies.Arc.Models.Interfaces;

namespace UpcomingMovies.Arc.ViewModels.Interfaces
{
    public interface IUpcomingMoviesListViewModel
    {
        ObservableRangeCollection<IUpcomingMovie> Items { get; set; }
        Task LoadListItems();
        Task LoadLazyList(IUpcomingMovie item);
        Task SearchMovieByFilter(string term);
    }
}
