﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Arc.ApiClient;
using UpcomingMovies.Arc.ApiClient.Services;
using UpcomingMovies.Arc.Ioc;
using UpcomingMovies.Arc.Models;
using UpcomingMovies.Arc.Models.Helpers;
using UpcomingMovies.Arc.Models.Interfaces;
using UpcomingMovies.Arc.ViewModels.Interfaces;
using Xamarin.Forms;

namespace UpcomingMovies.Arc.ViewModels
{
    public class UpcomingMoviesListViewModel : ObservableObject, IUpcomingMoviesListViewModel
    {
        private ObservableRangeCollection<UpcomingMovie> _items;

        public ObservableRangeCollection<UpcomingMovie> Items
        {
            get { return _items; }
            set
            {
                SetProperty(ref _items, value);
            }
        }

        public UpcomingMoviesListViewModel()
        {
        }

        public async Task LoadListItems()
        {
            //load the genres
            await LoadGenres();           
        }

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
            var apiResult = await Resolver.Get<IUpcomingMoviesService>().GetPagedUpcomingWithGenre();
            Items = new ObservableRangeCollection<UpcomingMovie>(apiResult);
        }

    }
}