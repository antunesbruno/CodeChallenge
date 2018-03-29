using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public partial class UpcomingMovieDetailView : ContentPage, IUpcomingMovieDetailView
    {
        public IUpcomingMovie SelectedItem { get; set; }

        public UpcomingMovieDetailView()
        {
            InitializeComponent();

            //set binding context
            this.BindingContext = Resolver.Get<IUpcomingMovieDetailViewModel>();           
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //set parameter to viewmodel
            (this.BindingContext as IUpcomingMovieDetailViewModel).SelectedItem = this.SelectedItem;

        }
    }
}