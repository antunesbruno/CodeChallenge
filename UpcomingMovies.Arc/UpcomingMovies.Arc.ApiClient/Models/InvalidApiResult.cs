using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
