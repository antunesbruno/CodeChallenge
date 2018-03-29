using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Arc.Models.Interfaces;

namespace UpcomingMovies.Arc.ViewModels.Interfaces
{
    public interface IUpcomingMovieDetailViewModel
    {
        IUpcomingMovie SelectedItem { get; set; }
    }
}
