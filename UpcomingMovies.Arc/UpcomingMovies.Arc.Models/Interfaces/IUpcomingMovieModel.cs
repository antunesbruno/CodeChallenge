using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpcomingMovies.Arc.Models.Interfaces
{
    public interface IUpcomingMovie
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
        object Genre_Ids { get; set; }
        string Backdrop_path { get; set; }
        bool Adult { get; set; }
        string Overview { get; set; }
        string Release_Date { get; set; }
    }
}
