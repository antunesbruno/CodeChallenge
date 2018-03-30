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
        #region Properties        

        /// <summary>
        /// Item selected in list
        /// </summary>
        public IUpcomingMovie SelectedItem { get; set; }

        #endregion

        #region Constructor        

        public UpcomingMovieDetailView()
        {
            InitializeComponent();

            //set binding context
            this.BindingContext = Resolver.Get<IUpcomingMovieDetailViewModel>();           
        }

        #endregion

        #region Events        

        /// <summary>
        /// Execute when view appearing
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //set parameter to viewmodel
            (this.BindingContext as IUpcomingMovieDetailViewModel).SelectedItem = this.SelectedItem;

        }

        #endregion
    }
}