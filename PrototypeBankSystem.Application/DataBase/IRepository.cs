using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Application.DateBase
{
    public interface IRepository<T>
        where T: class
    {
        Task<IEnumerable<T>> GetAll();
        Task CreateClient(Client entity);
        Task CreateCard(CreditCard entity);
        Task CreateCredit(Credit entity);
        Task CreateDeposit(Deposit entity);
        Task Update(T entity, T entityOld);
        Task Delete(T entity);
        Task Save(IEnumerable<T> ts); 
    }
}
