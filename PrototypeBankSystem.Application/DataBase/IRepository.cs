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

        //Task DeleteClientCard(ClientCard entity);
        //Task DeleteClient(Client entity);
        //Task DeleteDeposit(Deposit entity);
        //Task DeleteCredit(Credit entity);
    }
}
