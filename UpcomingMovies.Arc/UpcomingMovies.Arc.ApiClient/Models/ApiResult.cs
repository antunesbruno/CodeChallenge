namespace UpcomingMovies.Arc.ApiClient
{
    public sealed class ApiResult<TModel>
    {
        public bool Success { get; set; }
        public TModel Data { get; set; }
    }
}
