using System.Collections.Generic;
using System.Threading.Tasks;
using UpcomingMovies.Arc.Models;

namespace UpcomingMovies.Arc.ApiClient.Services
{
    public interface IUpcomingMoviesService
    {
        Task<List<UpcomingMovie>> GetAllUpComingMovies(int page);
        Task<List<UpcomingMovie>> GetPagedUpcomingWithGenre(int page);
        Task<List<UpcomingMovie>> SearchMoviesByTerm(string term);
    }
}
