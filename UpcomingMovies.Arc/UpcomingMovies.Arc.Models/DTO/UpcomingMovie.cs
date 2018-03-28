﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Arc.Models.Helpers;
using UpcomingMovies.Arc.Models.Interfaces;
using Xamarin.Forms;

namespace UpcomingMovies.Arc.Models
{
    public class UpcomingMovie : ObservableObject, IUpcomingMovie
    {
        public int Vote_Count { get; set; }
        public int Id { get; set; }
        public bool Video { get; set; }
        public double Vote_Average { get; set; }
        public string Title { get; set; }
        public double Popularity { get; set; }
        public string Poster_path { get; set; }
        public string Original_Language { get; set; }
        public string Original_Title { get; set; }
        public object Genre_Ids { get; set; }
        public string Backdrop_path { get; set; }
        public bool Adult { get; set; }
        public string Overview { get; set; }
        public string Release_Date { get; set; }

        private ImageSource testImageSource;
        public ImageSource TestImageSource
        {
            get { return ImageSource.FromUri(new Uri("https://image.tmdb.org/t/p/w500" + Backdrop_path)); }

        }
    }
}
