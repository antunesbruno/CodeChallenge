using System.Threading.Tasks;
using UpcomingMovies.Arc.ApiClient.Services;
using UpcomingMovies.Arc.Ioc;
using UpcomingMovies.Arc.Models;
using UpcomingMovies.Arc.Models.Helpers;
using UpcomingMovies.Arc.Models.Interfaces;
using UpcomingMovies.Arc.ViewModels.Interfaces;

namespace UpcomingMovies.Arc.ViewModels
{
    public class UpcomingMoviesListViewModel : BaseViewModel, IUpcomingMoviesListViewModel
    {
        #region Fields        

        private int _pageItem = 1;
        private ObservableRangeCollection<UpcomingMovie> _items;

        #endregion

        #region Properties

        public ObservableRangeCollection<UpcomingMovie> Items
        {
            get { return _items; }
            set
            {
                SetProperty(ref _items, value);
            }
        }

        #endregion

        #region Constructor       

        public UpcomingMoviesListViewModel()
        {
            TitleView = "Upcoming Movies";
        }

        #endregion

        #region Public Methods        

        /// <summary>
        /// Load list items
        /// </summary>
        /// <returns></returns>
        public async Task LoadListItems()
        {
            //instance the list
            if (Items == null)
                Items = new ObservableRangeCollection<UpcomingMovie>();

            //show indicator
            ShowIndicator();

            //load the genres
            await LoadGenres();
        }

        /// <summary>
        /// Execute the load list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task LoadLazyList(IUpcomingMovie item)
        {
            if (Items.Count == 0)
                return;

            //hit bottom!
            if (item == Items[Items.Count - 1])
            {
                //show indicator
                ShowIndicator();

                //increment the page
                _pageItem++;

                //load more items
                GetPagedItems();
            }
        }

        #endregion

        #region Private Methods        

        /// <summary>
        /// Load All Genres
        /// </summary>
        /// <returns></returns>
        private async Task LoadGenres()
        {
            //genres
            await Resolver.Get<IGenreService>().GetAllGenre(ExecuteLoadListCallBack);
        }

        /// <summary>
        /// Execute callback after call genres
        /// </summary>
        private async void ExecuteLoadListCallBack()
        {
            GetPagedItems();
        }

        /// <summary>
        /// Get the paged upcoming movies items
        /// </summary>
        private async void GetPagedItems()
        {
            var apiResult = await Resolver.Get<IUpcomingMoviesService>().GetPagedUpcomingWithGenre(_pageItem);
            Items.AddRange(new ObservableRangeCollection<UpcomingMovie>(apiResult));

            //hide indicator
            HideIndicator();
        }

        #endregion

    }
}
