using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Persistence.DataBase.Repository
{
    public class CreditRepository : IRepository<Credit>
    {
        public async Task<Credit> Create(Credit entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            await context.Credit.AddAsync(entity);
            return context.Credit.Where(c => c.ID == entity.ID).SingleOrDefault();
        }

        public async Task<Credit> Delete(Credit entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            context.Credit.Remove(entity);
            return entity;
        }

        public async Task<IEnumerable<Credit>> GetAll()
        {
            using ApplicationContext context = new();
            return context.Credit.ToList();
        }

        public async Task<Credit> GetByID(string id)
        {
            var res = int.TryParse(id, out var cardID);
            if (id == null || !res)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            return context.Credit.Where(c => c.ID == cardID).SingleOrDefault();
        }

        public async Task<Credit> Update(Credit entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            context.Credit.Update(entity);
            return entity;
        }
    }
}
