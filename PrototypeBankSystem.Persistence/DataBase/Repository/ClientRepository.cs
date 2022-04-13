using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Persistence.DataBase.Repository
{
    public class ClientRepository : IRepository<Client>
    {
        public async Task<Client> Create(Client entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            await context.Client.AddAsync(entity);
            return context.Client.Where(c => c.ID == entity.ID).SingleOrDefault();
        }

        public async Task<Client> Delete(Client entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            context.Client.Remove(entity);
            return entity;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            using ApplicationContext context = new();
            return context.Client.ToList();
        }

        public async Task<Client> GetByID(string id)
        {
            var res = Guid.TryParse(id, out var cardID);
            if (id == null || !res)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            return context.Client.Where(c => c.ID == cardID).SingleOrDefault();
        }

        public async Task<Client> Update(Client entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            using ApplicationContext context = new();
            context.Client.Update(entity);
            return entity;
        }
    }
}
