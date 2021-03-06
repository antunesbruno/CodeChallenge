﻿using System.Collections.Generic;
using Xamarin.Forms;

namespace UpcomingMovies.Arc.Models.Interfaces
{
    public interface IUpcomingMovie : IModel
    {
        int Vote_Count { get; set; }
        int Id { get; set; }
        bool Video { get; set; }
        double Vote_Average { get; set; }
        string Title { get; set; }
        double Popularity { get; set; }
        string Poster_path { get; set; }
        string Original_Language { get; set; }
        string Original_Title { get; set; }
        int[] Genre_Ids { get; set; }
        string Backdrop_path { get; set; }
        bool Adult { get; set; }
        string Overview { get; set; }
        string Release_Date { get; set; }
        List<Genres> Genre { get; set; }
        ImageSource ImageSourceBackDrop { get; }
        ImageSource ImageSourcePosterPath { get; }
        string GenresByComma { get; }
    }
}
