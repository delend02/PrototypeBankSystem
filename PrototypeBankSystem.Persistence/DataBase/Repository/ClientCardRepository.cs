using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Persistence.DataBase.Repository
{
    public class ClientCardRepository : IRepository<ClientCard>
    {
        public async Task<ClientCard> Create(ClientCard entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            using ApplicationContext context = new ();
            await context.ClientCard.AddAsync(entity);
            return context.ClientCard.Where(c => c.ID == entity.ID).SingleOrDefault();
        }

        public async Task<ClientCard> Delete(ClientCard entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            context.ClientCard.Remove(entity);
            return entity;
        }

        public async Task<IEnumerable<ClientCard>> GetAll()
        {
            using ApplicationContext context = new();
            return context.ClientCard.ToList();
        }

        public async Task<ClientCard> GetByID(string id)
        {
            var res = int.TryParse(id, out var cardID);
            if (id == null || !res)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            return context.ClientCard.Where(c => c.ID == cardID).SingleOrDefault();
        }

        public async Task<ClientCard> Update(ClientCard entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            context.ClientCard.Update(entity);
            return entity;
        }
    }
}
