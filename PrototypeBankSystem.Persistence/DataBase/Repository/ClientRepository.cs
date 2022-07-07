namespace PrototypeBankSystem.Persistence.DataBase.Repository
{
    public class ClientRepository : IRepository<Client>
    {
        readonly ApplicationContext context;

        public ClientRepository(ApplicationContext db)
        {
            context = db;
        }

        public async Task<Client> Create(Client entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            await context.Client.AddAsync(entity);

            return await context.Client.FindAsync(entity.ID);
        }

        public async Task<Client> Delete(string id)
        {
            var res = Guid.TryParse(id, out var clientID);

            var client = await context.Client.FindAsync(clientID);

            if (id == null || !res || client == null)
                throw new ArgumentNullException();

            context.Client.Remove(client);

            return client;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return context.Client.ToList();
        }

        public async Task<Client> GetByID(string id)
        {
            var res = Guid.TryParse(id, out var clientID);
            var client = await context.Client.FindAsync(clientID);

            if (id == null || !res || client is null)
                throw new ArgumentNullException();

            return client;
        }

        public async Task<Client> Update(Client entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            context.Client.Update(entity);

            return entity;
        }
    }
}
