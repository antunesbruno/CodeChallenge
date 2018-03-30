namespace UpcomingMovies.Arc.Models.Interfaces
{
    public interface IGenres : IModel
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
