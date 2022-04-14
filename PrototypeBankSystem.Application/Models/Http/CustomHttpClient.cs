using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace PrototypeBankSystem.Application.Models.Http
{
    public class CustomHttpClient
    {
        private HttpClient Client { get; set; }

        public CustomHttpClient(Uri baseAddress)
        {
            var clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            Client = new HttpClient(clientHandler)
            {
                BaseAddress = baseAddress
            };

            //Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(privateApiKey);
        }
        public async Task<T> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
        {
            var response = await Client.GetAsync(endpoint, cancellationToken);

            return await GetDataFromResponseAsync<T>(response);
        }

        public async Task<T> PostAsync<T>(string endpoint, FormUrlEncodedContent formData, CancellationToken cancellationToken = default)
        {
            var response = await Client.PostAsync(endpoint, formData, cancellationToken);

            return await GetDataFromResponseAsync<T>(response);
        }

        public async Task<TOut> PostAsJsonAsync<TIn, TOut>(string endpoint, TIn data, CancellationToken cancellationToken = default)
        {
            var response = await Client.PostAsJsonAsync(endpoint, data, JsonUtility.JsonOptions, cancellationToken: cancellationToken);

            return await GetDataFromResponseAsync<TOut>(response);
        }

        private static async Task<T> GetDataFromResponseAsync<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
#if DEBUG
                Console.WriteLine($"Error for '{response.RequestMessage.RequestUri}': {response.StatusCode}");
#endif
            }

            var json = await response.Content.ReadAsStringAsync();

            return JsonUtility.GetData<T>(json);
        }
    }

    public class HttpEntityException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public HttpEntityException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }

    public static class JsonUtility
    {
        public static JsonSerializerOptions JsonOptions { get; } = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        public static string GetJson<T>(T data) => JsonSerializer.Serialize(data, JsonOptions);
        public static T GetData<T>(string json) => JsonSerializer.Deserialize<T>(json, JsonOptions);
    }
}

