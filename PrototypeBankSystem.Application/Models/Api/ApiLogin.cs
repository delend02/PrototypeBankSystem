using PrototypeBankSystem.Application.DTO;
using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Application.Models.Api
{
    public static class ApiLogin
    {

        public static async Task<Admin> LoginAsync(AdminLoginDTO adminLoginDTO, CancellationToken cancellationToken = default)
        {
            var url = $"{ApiEndpoints.Login}";

            return await Api.Client.PostAsJsonAsync<AdminLoginDTO, Admin>(url, adminLoginDTO, cancellationToken);
        }
    }
}
