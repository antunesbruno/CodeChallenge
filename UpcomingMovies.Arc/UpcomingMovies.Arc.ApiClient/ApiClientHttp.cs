﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UpcomingMovies.Arc.ApiClient
{
    public class ApiClientHttp : IApiClientHttp
    {
        private HttpClient _restClient;
        private string _apiUrlBase;

        public void SetApiClientHttp(string apiUrlBase)
        {
            if (string.IsNullOrEmpty(apiUrlBase))
            {
                throw new ArgumentNullException("apiUrlBase", "Uma url base de API deve ser informada");
            }

            _apiUrlBase = apiUrlBase;
        }

        public async Task<BaseApiResult<TModel>> GetAsync<TModel>(string apiRoute, Action<BaseApiResult<TModel>> callback = null)
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

        private async Task<string> GetAsync(string apiRoute)
        {
            var url = _apiUrlBase + "/" + apiRoute;

            _restClient = _restClient ?? new HttpClient();
            _restClient.BaseAddress = new Uri(url);

            ClearReponseHeaders();
            AddReponseHeaders();

            var response = await _restClient.GetAsync(_restClient.BaseAddress);
            response.EnsureSuccessStatusCode();
            var data = response.Content.ReadAsStringAsync().Result;

            return data;
        }

        private IsoDateTimeConverter GetConverter()
        {
            return new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" };
        }

        public IApiClientHttp UseSufix(string urlSufix)
        {
            if (!_apiUrlBase.EndsWith(urlSufix))
            {
                _apiUrlBase = _apiUrlBase + "/" + urlSufix;
            }

            return this;
        }

        private void AddReponseHeaders()
        {

        }

        private void ClearReponseHeaders()
        {
            _restClient.DefaultRequestHeaders.Clear();
        }

        public void Dispose()
        {

        }

    }
}
