using UpcomingMovies.Arc.Models.Interfaces;
using UpcomingMovies.Arc.ViewModels.Interfaces;

namespace UpcomingMovies.Arc.ViewModels
{
    public class UpcomingMovieDetailViewModel : BaseViewModel<IUpcomingMovie>, IUpcomingMovieDetailViewModel
    {
        #region Constructor        

        public UpcomingMovieDetailViewModel()
        {
            TitleView = "Movie Detail";
        }

        #endregion

        #region Properties        

        private IUpcomingMovie _selectedItem;
        public IUpcomingMovie SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }

        #endregion
    }
}
