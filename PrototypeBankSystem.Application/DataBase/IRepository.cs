using PrototypeBankSystem.Application.DTO;
using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Application.DateBase
{
    public interface IRepository<T>
        where T : class
    {
        Task<IEnumerable<Client>> GetAllClient();
        Task<IEnumerable<ClientCardInfoDTO>> GetClientInfoCard();
        Task CreateClient(Client entity);
        Task CreateCard(CreditCard entity);
        Task CreateCredit(Credit entity);
        Task CreateDeposit(Deposit entity);
    }
}
