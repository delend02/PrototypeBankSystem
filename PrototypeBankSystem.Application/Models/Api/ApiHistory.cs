using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Application.Models.Api
{
    public class ApiHistory
    {
        public static async Task<IEnumerable<History>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.History}";
            return await Api.Client.GetAsync<IEnumerable<History>>(url, cancellationToken);
        }
    }
}
