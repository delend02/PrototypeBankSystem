using PrototypeBankSystem.BLL.Entities;

namespace PrototypeBankSystem.API.ApiLayer.Api
{
    public static class ApiDeposit
    {
        public static async Task<IEnumerable<Deposit>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Deposit}";
            return await Api.Client.GetAsync<IEnumerable<Deposit>>(url, cancellationToken);
        }

        public static async Task<Deposit> GetByIDAsync(int id, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Deposit}/{id}";
            return await Api.Client.GetAsync<Deposit>(url, cancellationToken);
        }

        public static async Task<Deposit> CreateAsync(Deposit client, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Deposit}";

            return await Api.Client.PostAsJsonAsync<Deposit, Deposit>(url, client, cancellationToken);
        }

        public static async Task<Deposit> UpdateAsync(Deposit deposit, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Deposit}";

            return await Api.Client.PutAsJsonAsync<Deposit, Deposit>(url, deposit, cancellationToken);
        }

        public static async Task<Deposit> DeleteAsync(Deposit deposit, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Deposit}/{deposit.ID}";

            return await Api.Client.DeleteAsync<Deposit>(url, cancellationToken);
        }

    }
}
