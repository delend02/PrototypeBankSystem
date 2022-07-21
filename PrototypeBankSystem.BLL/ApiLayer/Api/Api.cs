using PrototypeBankSystem.BLL.ApiLayer.Http;

namespace PrototypeBankSystem.BLL.ApiLayer.Api
{
    public static class Api
    {
        public static CustomHttpClient Client { get; private set; }

        static Api()
        {
            var baseUrl = "https://localhost:5001/";

            Console.WriteLine($"BaseUrl: {baseUrl}");

            Client = new CustomHttpClient(new Uri(baseUrl));
        }
    }
}
