using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpcomingMovies.Arc.ApiClient
{
    public interface IApiClientHttp
    {
        void SetApiClientHttp(string apiUrlBase);
        Task<BaseApiResult<T>> GetAsync<T>(string apiRoute, Action<BaseApiResult<T>> callback = null);
    }
}
