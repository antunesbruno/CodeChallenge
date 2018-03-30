namespace UpcomingMovies.Arc.ApiClient
{
    public sealed class OkApiResult<T> : BaseApiResult<T>
    {
        public OkApiResult()
        {
            Success = false;            
        }

        public OkApiResult(T data)
            : this()
        {
            Success = true;
            results = data;
        }
    }
}
