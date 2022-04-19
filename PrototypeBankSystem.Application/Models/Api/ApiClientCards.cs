using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Application.Models.Api
{
    public static class ApiClientCards
    {
        public static async Task<IEnumerable<ClientCard>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.ClientCard}";
            return await Api.Client.GetAsync<IEnumerable<ClientCard>>(url, cancellationToken);
        }

        public static async Task<ClientCard> GetByIDAsync(int id, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.ClientCard}/{id}";
            return await Api.Client.GetAsync<ClientCard>(url, cancellationToken);
        }

        public static async Task<ClientCard> CreateAsync(ClientCard client, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.ClientCard}";

            return await Api.Client.PostAsJsonAsync<ClientCard, ClientCard>(url, client, cancellationToken);
        }

        public static async Task<ClientCard> UpdateAsync(ClientCard clientCard, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.ClientCard}";

            return await Api.Client.PutAsJsonAsync<ClientCard, ClientCard>(url, clientCard, cancellationToken);
        }

    }
}
