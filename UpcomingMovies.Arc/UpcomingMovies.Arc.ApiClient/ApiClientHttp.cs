using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UpcomingMovies.Arc.ApiClient.Enums;
using UpcomingMovies.Arc.ApiClient.Models;

namespace UpcomingMovies.Arc.ApiClient
{
    public class ApiClientHttp : IApiClientHttp
    {
        #region Fields        

        private HttpClient _restClient;
        private string _apiUrlBase = EndPointEnum.BaseAddress;

        #endregion

        #region API Http Methods        

        /// <summary>
        /// Get Data Async
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="apiRoute"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task<BaseApiResult<TModel>> GetAsync<TModel>(string apiRoute, Action<BaseApiResult<TModel>> callback = null)
        {
            try
            {
                var json = await GetAsync(apiRoute);
                var data = JsonConvert.DeserializeObject<BaseApiResult<TModel>>(json, GetConverter());
                var result = new OkApiResult<TModel>(data.results);

                callback?.Invoke(result);

                return result;
            }
            catch (Exception ex)
            {
                return new InvalidApiResult<TModel>(ex);
            }
        }

        /// <summary>
        /// Get Data Async without use the class BaseApiResult
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="apiRoute"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public async Task<BaseApiResult<TModel>> GetAsyncWithoutBaseApi<TModel>(string apiRoute, Action<BaseApiResult<TModel>> callback = null)
        {
            try
            {
                var json = await GetAsync(apiRoute);
                var data = JsonConvert.DeserializeObject<TModel>(json, GetConverter());
                var result = new OkApiResult<TModel>(data);

                callback?.Invoke(result);

                return result;
            }
            catch (Exception ex)
            {
                return new InvalidApiResult<TModel>(ex);
            }
        }

        #endregion

        #region Private Methods

        private async Task<string> GetAsync(string apiRoute)
        {
            var url = _apiUrlBase + apiRoute;              

            _restClient = _restClient ?? new HttpClient();
            _restClient.BaseAddress = new Uri(url);

            var response = await _restClient.GetAsync(_restClient.BaseAddress);
            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;

            return data;
        }
      
        private IsoDateTimeConverter GetConverter()
        {
            return new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" };
        }

        #endregion

        #region Aux Methods        

        public IApiClientHttp UseSufix(string urlSufix)
        {
            if (!_apiUrlBase.EndsWith(urlSufix))
            {
                _apiUrlBase = _apiUrlBase + "/" + urlSufix;
            }

            return this;
        }
        
        private void ClearReponseHeaders()
        {
            _restClient.DefaultRequestHeaders.Clear();
        }

        #endregion

    }
}
