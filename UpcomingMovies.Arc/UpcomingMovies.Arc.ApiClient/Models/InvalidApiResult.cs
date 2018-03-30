using System;

namespace UpcomingMovies.Arc.ApiClient.Models
{
    public class InvalidApiResult<T> : BaseApiResult<T>
    {
        public InvalidApiResult()
            : base()
        {
            Success = false;
        }

        public InvalidApiResult(Exception ex)
            : base()
        {
            Success = false;
            Message = ex.Message;
        }
    }
}
