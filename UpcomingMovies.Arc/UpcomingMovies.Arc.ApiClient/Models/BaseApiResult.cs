using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpcomingMovies.Arc.ApiClient
{
    public class BaseApiResult<T> : IApiResult<T>
    {
        public BaseApiResult()
        {

        }

        public T results { get; set; }
        public int page { get; set; }
        public int total_results { get; set; }
        public object dates { get; set; }
        public int total_pages { get; set; }

        public virtual object Minify()
        {
            return this;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
