using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Arc.ApiClient.Enums;
using UpcomingMovies.Arc.Ioc;
using UpcomingMovies.Arc.Models;

namespace UpcomingMovies.Arc.ApiClient.Services
{
    public class UpcomingMoviesService : IUpcomingMoviesService
    {
        private string _address = string.Format(ApiRouteEnum.UpcomingMovie, EndPointEnum.APIKey, "en-us", 1);

        public async Task<List<UpcomingMovie>> GetAllUpComingMovies()
        {
            //get the address
            var upcomingResult = await Resolver.Get<IApiClientHttp>().GetAsync<List<UpcomingMovie>>(_address);
            return upcomingResult.results ?? new List<UpcomingMovie>();
        }

        public async Task<List<UpcomingMovie>> GetPagedUpcomingWithGenre()
        {
            var listUpcoming = await this.GetAllUpComingMovies();

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
    }
}
