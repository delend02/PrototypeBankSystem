using PrototypeBankSystem.BLL.Entities;

namespace PrototypeBankSystem.BLL.Services
{
    public class HistoryServices
    {
        public static async Task<IEnumerable<History>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var url = $"{EndpointsServices.History}";
            return await Api.Client.GetAsync<IEnumerable<History>>(url, cancellationToken);
        }
    }
}
