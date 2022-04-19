using PrototypeBankSystem.Application.Models.Http;

namespace PrototypeBankSystem.Application.Models.Api
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
