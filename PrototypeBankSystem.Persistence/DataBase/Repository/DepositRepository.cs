using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Persistence.DataBase.Repository
{
    public class DepositRepository : IRepository<Deposit>
    {
        public async Task<Deposit> Create(Deposit entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            await context.Deposit.AddAsync(entity);
            return context.Deposit.Where(c => c.ID == entity.ID).SingleOrDefault();
        }

        public async Task<Deposit> Delete(Deposit entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            context.Deposit.Remove(entity);
            return entity;
        }

        public async Task<IEnumerable<Deposit>> GetAll()
        {
            using ApplicationContext context = new();
            return context.Deposit.ToList();
        }

        public async Task<Deposit> GetByID(string id)
        {
            var res = int.TryParse(id, out var cardID);
            if (id == null || !res)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            return context.Deposit.Where(c => c.ID == cardID).SingleOrDefault();
        }

        public async Task<Deposit> Update(Deposit entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            context.Deposit.Update(entity);
            return entity;
        }
    }
}
