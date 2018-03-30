using System.Threading.Tasks;
using UpcomingMovies.Arc.ApiClient.Services;
using UpcomingMovies.Arc.Ioc;
using UpcomingMovies.Arc.Models;
using UpcomingMovies.Arc.Models.Helpers;
using UpcomingMovies.Arc.Models.Interfaces;
using UpcomingMovies.Arc.ViewModels.Interfaces;
using UpcomingMovies.Arc.Views.Interfaces;

namespace UpcomingMovies.Arc.ViewModels
{
    public class UpcomingMoviesListViewModel : BaseViewModel<IUpcomingMovie>, IUpcomingMoviesListViewModel
    {
        #region Fields        

        private int _pageItem = 1;        
        private ObservableRangeCollection<IUpcomingMovie> _itemsBackup;

        #endregion

        #region Properties

        private ObservableRangeCollection<IUpcomingMovie> _items;
        public override ObservableRangeCollection<IUpcomingMovie> Items
        {
            get { return _items; }
            set
            {
                SetProperty(ref _items, value);
            }
        }

        private string _searchText;
        public override string SearchText
        {
            get { return _searchText; }
            set
            {
                //if cleaning value
                if (!string.IsNullOrEmpty(_searchText) && string.IsNullOrEmpty(value))
                {
                    Items = new ObservableRangeCollection<IUpcomingMovie>(_itemsBackup);
                }
                    
                SetProperty(ref _searchText, value);
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
                Items = new ObservableRangeCollection<IUpcomingMovie>();

            //show indicator
            ShowIndicator();

            //load the genres
            await LoadGenres();

            //do backup of data
            _itemsBackup = new ObservableRangeCollection<IUpcomingMovie>(Items);
        }

        /// <summary>
        /// Execute the load list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task LoadLazyList(IUpcomingMovie item)
        {
            if (string.IsNullOrEmpty(SearchText))
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

            //do backup of data
            _itemsBackup = new ObservableRangeCollection<IUpcomingMovie>(Items);

            //hide indicator
            HideIndicator();
        }

        #endregion

        #region Search Methods

        /// <summary>
        /// Execute the search of term
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public override async Task ExecuteSearchCommand()
        {
            //validate size of term
            if (SearchText?.Length >= 3)
            {
                //show loading
                ShowIndicator();

                //search by term
                await SearchMoviesByTerm(SearchText);
            }
            else
            {
                //show alert
                await ((Xamarin.Forms.Page)Resolver.Get<IUpcomingMoviesListView>()).DisplayAlert("Alert !", "You must digit at least 3 (three) caracters to search !", "OK");
            }
        }

        /// <summary>
        /// Search Movies By Term
        /// This service show only the 20 terms and is need to digit at least 3 caracters
        /// </summary>
        /// <returns></returns>
        private async Task SearchMoviesByTerm(string term)
        {
            //search
            var result = await Resolver.Get<IUpcomingMoviesService>().SearchMoviesByTerm(term);

            if (result?.Count > 0)
            {
                //clean items
                Items.Clear();

                //show list of itens search
                Items = new ObservableRangeCollection<IUpcomingMovie>(result);
            }

            //hide indicator
            HideIndicator();
        }
        
        #endregion       

    }
}
