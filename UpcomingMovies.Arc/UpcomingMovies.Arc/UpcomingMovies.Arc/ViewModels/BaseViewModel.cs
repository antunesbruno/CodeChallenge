using System.Threading.Tasks;
using UpcomingMovies.Arc.ApiClient.Services;
using UpcomingMovies.Arc.Ioc;
using UpcomingMovies.Arc.Models;
using UpcomingMovies.Arc.Models.Helpers;
using UpcomingMovies.Arc.Models.Interfaces;
using UpcomingMovies.Arc.Services;
using UpcomingMovies.Arc.Views.Interfaces;
using Xamarin.Forms;

namespace UpcomingMovies.Arc.ViewModels
{
    public class BaseViewModel<T> : ObservableObject 
        where T : IModel
    {        
        public virtual string BackButtonTitle { get; set; } = "Back";

        private ObservableRangeCollection<T> _items;
        public virtual ObservableRangeCollection<T> Items
        {
            get { return _items; }
            set
            {
                SetProperty(ref _items, value);
            }
        }

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

        #region Search Methods

        /// <summary>
        /// Execute the search of term
        /// </summary>
        /// <param name="term"></param>
        /// <returns></returns>
        public async Task SearchMovieByFilter(string term)
        {
            //first search local in items
            var _itemsFiltered = new ObservableRangeCollection<UpcomingMovie>(FilterListItem(term));

            //if searched the items
            if (_itemsFiltered != null)
                Items = _itemsFiltered;
            else
            {
                //search online
                if (term.Length >= 3)
                {
                    //show loading
                    ShowIndicator();

                    await SearchMoviesByTerm(term);
                }
                else
                {
                    //show alert
                    await ((Xamarin.Forms.Page)Resolver.Get<IUpcomingMoviesListView>()).DisplayAlert("Alert !", "You must digit at least 3 (three) caracters to search !", "OK");
                }
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

            if (result != null)
            {
                //refresh backup
                _itemsBackup = Items;

                //clean items
                Items.Clear();

                //show list of itens search
                Items = new ObservableRangeCollection<UpcomingMovie>(result);
            }

            //hide indicator
            HideIndicator();
        }

        /// <summary>
        /// Filtra os itens conforme os campos espeficicados abaixo
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<UpcomingMovie> FilterListItem(string term)
        {
            var filteredList = Items.Where(z =>
                   //title
                   z.Title.ToLower().Contains(term.ToLower()) ||

                   //original title
                   z.Original_Title.ToLower().Contains(term.ToLower()));

            return filteredList.ToList();
        }


        #endregion
    }
}

