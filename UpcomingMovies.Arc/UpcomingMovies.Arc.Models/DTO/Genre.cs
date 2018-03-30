using System.Collections.Generic;
using UpcomingMovies.Arc.Models.Interfaces;

namespace UpcomingMovies.Arc.Models
{
    public class Genres : IGenres
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GenreRootObject
    {
        public List<Genres> genres { get; set; }
    }
}
