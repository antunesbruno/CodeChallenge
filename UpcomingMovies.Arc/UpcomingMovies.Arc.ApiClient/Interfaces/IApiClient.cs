using System;
using System.Threading.Tasks;

namespace UpcomingMovies.Arc.ApiClient
{
    public interface IApiClientHttp
    {
        Task<BaseApiResult<T>> GetAsync<T>(string apiRoute, Action<BaseApiResult<T>> callback = null);
        Task<BaseApiResult<TModel>> GetAsyncWithoutBaseApi<TModel>(string apiRoute, Action<BaseApiResult<TModel>> callback = null);
    }
}
