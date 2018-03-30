using UpcomingMovies.Arc.Ioc;
using UpcomingMovies.Arc.Models.Interfaces;
using UpcomingMovies.Arc.ViewModels.Interfaces;
using UpcomingMovies.Arc.Views.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UpcomingMovies.Arc.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpcomingMoviesListView : ContentPage, IUpcomingMoviesListView
    {
        #region Fields
                
        private bool _hasInitialized = false;

        #endregion

        #region Constructor        

        public UpcomingMoviesListView()
        {
            InitializeComponent();
            this.BindingContext = Resolver.Get<IUpcomingMoviesListViewModel>();
        }

        #endregion

        #region Events        

        /// <summary>
        /// Execute actions when view appearing
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!_hasInitialized)
            {
                _hasInitialized = true;
                await (this.BindingContext as IUpcomingMoviesListViewModel).LoadListItems();
            }
        }

        /// <summary>
        /// Execute when tap on item of list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //if null return to list
            if (e.Item == null)
                return;

            //declare view
            var upComingMovieDetailView = Resolver.Get<IUpcomingMovieDetailView>();
            upComingMovieDetailView.SelectedItem = (IUpcomingMovie)e.Item;

            //push async to detail
            await Navigation.PushAsync((Page)upComingMovieDetailView);

            // prevents the list from displaying the navigated item as selected when navigating back to the list
            ((ListView)sender).SelectedItem = null;
        }

        /// <summary>
        /// Execute when the item of listview apearing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await (this.BindingContext as IUpcomingMoviesListViewModel).LoadLazyList((IUpcomingMovie)e.Item);
        }

        #endregion
    }
}