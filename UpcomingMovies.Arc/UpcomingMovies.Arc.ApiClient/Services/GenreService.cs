using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UpcomingMovies.Arc.ApiClient.Enums;
using UpcomingMovies.Arc.Ioc;
using UpcomingMovies.Arc.Models;

namespace UpcomingMovies.Arc.ApiClient.Services
{
    /// <summary>
    /// Get Genre of The Movie DB API
    /// </summary>
    public class GenreService : IGenreService
    {
        #region Fields        

        //Genre Address
        private string _address = string.Format(ApiRouteEnum.GenreMovie, EndPointEnum.APIKey, "en-us");

        #endregion

        #region Properties        

        public List<Genres> GenreCached { get; set; }

        #endregion

        #region Service Methods        

        /// <summary>
        /// Get All Genres in API
        /// </summary>
        /// <returns></returns>
        public async Task<List<Genres>> GetAllGenre(Action callback = null)
        {
            //get genres
            var genreResult = await Resolver.Get<IApiClientHttp>().GetAsyncWithoutBaseApi<GenreRootObject>(_address);

            //update cache
            GenreCached = genreResult.results.genres ?? new List<Genres>();

            //execute callback
            callback?.Invoke();

            //return result
            return GenreCached;
        }

        #endregion
    }
}
