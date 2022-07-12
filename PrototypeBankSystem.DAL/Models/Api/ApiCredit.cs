using PrototypeBankSystem.BLL.Entities;

namespace PrototypeBankSystem.DAL.Models.Api
{
    public static class ApiCredit
    {
        public static async Task<IEnumerable<Credit>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Credit}";
            return await Api.Client.GetAsync<IEnumerable<Credit>>(url, cancellationToken);
        }

        public static async Task<Credit> GetByIDAsync(int id, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Credit}/{id}";
            return await Api.Client.GetAsync<Credit>(url, cancellationToken);
        }

        public static async Task<Credit> CreateAsync(Credit client, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Credit}";

            return await Api.Client.PostAsJsonAsync<Credit, Credit>(url, client, cancellationToken);
        }

        public static async Task<Credit> UpdateAsync(Credit credit, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Credit}";

            return await Api.Client.PutAsJsonAsync<Credit, Credit>(url, credit, cancellationToken);
        }

        public static async Task<Credit> DeleteAsync(Credit credit, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Credit}/{credit.ID}";

            return await Api.Client.DeleteAsync<Credit>(url, cancellationToken);
        }
    }
}
