using UpcomingMovies.Arc.Models;
using UpcomingMovies.Arc.Models.Helpers;
using UpcomingMovies.Arc.Services;

using Xamarin.Forms;

namespace UpcomingMovies.Arc.ViewModels
{
    public class BaseViewModel : ObservableObject
    {        
        public virtual string BackButtonTitle { get; set; } = "Back";

        bool isLoading = false;
        public bool IsLoading
        {
            get { return isLoading; }
            set { SetProperty(ref isLoading, value); }
        }
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string titleView = string.Empty;
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string TitleView
        {
            get { return titleView; }
            set { SetProperty(ref titleView, value); }
        }

        public void ShowIndicator()
        {
            IsLoading = true;
        }

        public void HideIndicator()
        {
            IsLoading = false;
        }
    }
}

