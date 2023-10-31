using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel.Channels;

namespace PAD2023.Presentation.Client
{
    public class HttpClientWrapper : IClient
    {
        private HttpClient _httpClient;

        public HttpClientWrapper()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders
                .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                T? responseResult = await response.Content.ReadFromJsonAsync<T>();
                if (responseResult == null)
                    throw new Exception();
                 
                return responseResult;
            }
            else
            {
                string mensaje = await response.Content.ReadAsStringAsync();
                throw new Exception(mensaje);
            }
        }

        private bool _disposed = false;

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
