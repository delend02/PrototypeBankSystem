using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Application.Models.Api
{
    public static class ApiClient
    {
        public static async Task<IEnumerable<Client>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Client}";
            return await Api.Client.GetAsync<IEnumerable<Client>>(url, cancellationToken);
        }

        public static async Task<Client> GetByIDAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Client}/{id}";
            return await Api.Client.GetAsync<Client>(url, cancellationToken);
        }

        public static async Task<Client> CreateAsync(Client client, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Client}";

            return await Api.Client.PostAsJsonAsync<Client, Client>(url, client, cancellationToken);
        }

        public static async Task<Client> UpdateAsync(Client client, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Client}";

            return await Api.Client.PutAsJsonAsync<Client, Client>(url, client, cancellationToken);
        }
    }
}
