using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpcomingMovies.Arc.ViewModels.Interfaces
{
    public interface IUpcomingMoviesListViewModel
    {
        Task LoadListItems();
    }
}
