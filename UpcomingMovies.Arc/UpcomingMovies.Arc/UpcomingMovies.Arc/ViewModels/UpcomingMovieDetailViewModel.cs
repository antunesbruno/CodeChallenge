using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Arc.Models.Helpers;
using UpcomingMovies.Arc.Models.Interfaces;
using UpcomingMovies.Arc.ViewModels.Interfaces;

namespace UpcomingMovies.Arc.ViewModels
{
    public class UpcomingMovieDetailViewModel : BaseViewModel, IUpcomingMovieDetailViewModel
    {
        public UpcomingMovieDetailViewModel()
        {
            TitleView = "Movie Detail";
        }

        private IUpcomingMovie _selectedItem;
        public IUpcomingMovie SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }
    }
}
