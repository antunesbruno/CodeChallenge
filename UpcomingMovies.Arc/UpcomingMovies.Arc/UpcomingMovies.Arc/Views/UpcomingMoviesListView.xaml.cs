using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using UpcomingMovies.Arc.Ioc;
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

        async void Handle_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (this.BindingContext as IUpcomingMoviesListViewModel).LoadListItems();
        }
    }
}