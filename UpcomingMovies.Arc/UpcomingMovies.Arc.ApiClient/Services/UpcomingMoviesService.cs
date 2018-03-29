using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Arc.ApiClient.Enums;
using UpcomingMovies.Arc.Ioc;
using UpcomingMovies.Arc.Models;

namespace UpcomingMovies.Arc.ApiClient.Services
{
    public class UpcomingMoviesService : IUpcomingMoviesService
    {
        /// <summary>
        /// Get all upcoming movies by page (this is a feature of the API)
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<List<UpcomingMovie>> GetAllUpComingMovies(int page)
        {
            //configura address
            var _address = string.Format(ApiRouteEnum.UpcomingMovie, EndPointEnum.APIKey, "en-us", page);

            //get data
            var upcomingResult = await Resolver.Get<IApiClientHttp>().GetAsync<List<UpcomingMovie>>(_address);
            return upcomingResult.results ?? new List<UpcomingMovie>();
        }

        /// <summary>
        /// Get the paged upcoming and set the genres in the list
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<List<UpcomingMovie>> GetPagedUpcomingWithGenre(int page)
        {
            var listUpcoming = await this.GetAllUpComingMovies(page);

            if (listUpcoming != null)
            {
                //get cached list of genre
                var genreList = Resolver.Get<IGenreService>().GenreCached;

                //if has genre
                if (genreList != null)
                {
                    //iterate the itens
                    foreach (var item in listUpcoming)
                    {
                        var genreIds = string.Join(",", item.Genre_Ids.ToList());
                        item.Genre = genreList.Where(g => genreIds.Contains(g.Id.ToString())).ToList();
                    }
                }
            }

            return listUpcoming;
        }

        /// <summary>
        /// Get all upcoming movies by page (this is a feature of the API)
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<List<UpcomingMovie>> SearchMoviesByTerm(string term)
        {
            //configura address
            var _address = string.Format(ApiRouteEnum.SearchMovie, EndPointEnum.APIKey, "en-us", WebUtility.UrlEncode(term));

            //get data
            var upcomingResult = await Resolver.Get<IApiClientHttp>().GetAsync<List<UpcomingMovie>>(_address);
            return upcomingResult.results ?? new List<UpcomingMovie>();
        }
    }
}
