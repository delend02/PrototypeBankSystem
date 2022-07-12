using PrototypeBankSystem.DAL.DTO;
using PrototypeBankSystem.BLL.Entities;

namespace PrototypeBankSystem.DAL.Models.Api
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
