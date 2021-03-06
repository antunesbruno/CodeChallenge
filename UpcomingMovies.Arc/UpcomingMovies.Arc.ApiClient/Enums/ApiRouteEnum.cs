﻿namespace UpcomingMovies.Arc.ApiClient.Enums
{
    public static class ApiRouteEnum
    {
        /// <summary>
        /// Genre  - Parameters ({0} - Key / {1} - language)
        /// </summary>
        public const string GenreMovie = "genre/movie/list?api_key={0}&language={1}";

        /// <summary>
        /// Upcoming - Parameters ({0} - Key / {1} - language / {2} - page)
        /// </summary>
        public const string UpcomingMovie = "movie/upcoming?api_key={0}&language={1}&page={2}";

        /// <summary>
        /// Search Movies - Parameters ({0} - Key / {1} - language / {2} - query)
        /// </summary>
        public const string SearchMovie = "search/movie?api_key={0}&language={1}&query={2}";       
        
    }
}
