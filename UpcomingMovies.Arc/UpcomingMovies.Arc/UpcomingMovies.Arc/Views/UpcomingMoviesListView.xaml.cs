using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
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
        public UpcomingMoviesListView()
        {
            InitializeComponent();
            this.BindingContext = Resolver.Get<IUpcomingMoviesListViewModel>();
        }       

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (this.BindingContext as IUpcomingMoviesListViewModel).LoadListItems();
        }

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

        private async void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await (this.BindingContext as IUpcomingMoviesListViewModel).LoadLazyList((IUpcomingMovie)e.Item);         
        }
    }
}