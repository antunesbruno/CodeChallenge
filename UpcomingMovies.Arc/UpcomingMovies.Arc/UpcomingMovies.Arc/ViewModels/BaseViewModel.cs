using System.Threading.Tasks;
using UpcomingMovies.Arc.Models.Helpers;
using UpcomingMovies.Arc.Models.Interfaces;
using Xamarin.Forms;

namespace UpcomingMovies.Arc.ViewModels
{
    public class BaseViewModel<T> : ObservableObject 
        where T : IModel
    {
        #region Properties        

        /// <summary>
        /// Back button title
        /// </summary>
        public virtual string BackButtonTitle { get; set; } = "Back";

        /// <summary>
        /// Search bar visibilty
        /// </summary>
        private bool _isVisibleSearchBar;
        public virtual bool IsVisibleSearchBar
        {
            get { return _isVisibleSearchBar; }
            set
            {
                SetProperty(ref _isVisibleSearchBar, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _searchText;
        public virtual string SearchText 
        {
            get { return _searchText; }
            set
            {
                SetProperty(ref _searchText, value);
            }
        }        

        /// <summary>
        /// Default List Items
        /// </summary>
        private ObservableRangeCollection<T> _items;
        public virtual ObservableRangeCollection<T> Items
        {
            get { return _items; }
            set
            {
                SetProperty(ref _items, value);
            }
        }

        /// <summary>
        /// Loading visibility of list
        /// </summary>
        bool isLoading = false;
        public bool IsLoading
        {
            get { return isLoading; }
            set { SetProperty(ref isLoading, value); }
        }

        /// <summary>
        /// Title view
        /// </summary>
        string titleView = string.Empty;
        public string TitleView
        {
            get { return titleView; }
            set { SetProperty(ref titleView, value); }
        }

        #endregion

        #region Methods        

        /// <summary>
        /// Show indicator
        /// </summary>
        public virtual void ShowIndicator()
        {
            IsLoading = true;
        }

        /// <summary>
        /// Hide indicator
        /// </summary>
        public virtual void HideIndicator()
        {
            IsLoading = false;
        }

        #endregion

        #region Commands

        /// <summary>
        /// Search Command
        /// </summary>
        private Command _SearchCommand;
        public Command SearchCommand
        {
            get { return _SearchCommand ?? (_SearchCommand = new Command(async () => await ExecuteSearchCommand())); }
        }

        /// <summary>
        /// Execute Action search
        /// </summary>
        /// <returns></returns>
        public virtual async Task ExecuteSearchCommand() { }

        /// <summary>
        /// Show search bar command
        /// </summary>
        private Command _ShowSearchCommand;
        public Command ShowSearchCommand
        {
            get { return _ShowSearchCommand ?? (_ShowSearchCommand = new Command(async () => await ExecuteShowSearchCommand())); }
        }

        /// <summary>
        /// Execute action to show search command bar
        /// </summary>
        /// <returns></returns>
        public virtual async Task ExecuteShowSearchCommand()
        {
            SearchText = string.Empty;
            IsVisibleSearchBar = !IsVisibleSearchBar;
        }

        #endregion
    }
}

