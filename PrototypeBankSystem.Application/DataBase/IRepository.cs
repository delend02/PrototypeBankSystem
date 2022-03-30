using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Application.DateBase
{
    public interface IRepository<T>
        where T : class
    {
        Task<IEnumerable<Client>> GetAllClient();

        Task CreateClient(Client entity);
        Task CreateCard(ClientCard entity);
        Task CreateCredit(Credit entity);
        Task CreateDeposit(Deposit entity);

        Task UpdateClientCard(ClientCard entity);
        Task UpdateClient(Client entity);
        Task UpdateDeposit(Deposit entity);
        Task UpdateCredit(Credit entity);
    }
}
