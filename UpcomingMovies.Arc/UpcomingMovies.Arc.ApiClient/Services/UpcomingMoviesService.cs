using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Arc.Ioc;
using UpcomingMovies.Arc.Models;

namespace UpcomingMovies.Arc.ApiClient.Services
{
    public class UpcomingMoviesService : IUpcomingMoviesService
    {
        public async Task<BaseApiResult<List<UpcomingMovie>>> GetAllUpComingMovies()
        {
            return await Resolver.Get<IApiClientHttp>().GetAsync<List<UpcomingMovie>>("");
        }
    }
}
