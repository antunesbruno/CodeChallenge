using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Arc.Models;

namespace UpcomingMovies.Arc.ApiClient.Services
{
    public interface IGenreService
    {
        Task<List<Genres>> GetAllGenre(Action callback = null);
        List<Genres> GenreCached { get; set; }
    }
}
