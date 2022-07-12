namespace PrototypeBankSystem.API.DataBase.Repository
{
    public class ClientCardRepository : IRepository<ClientCard>
    {
        readonly ApplicationContext context;

        public ClientCardRepository(ApplicationContext db)
        {
            context = db;
        }

        public async Task<ClientCard> Create(ClientCard entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            await context.ClientCard.AddAsync(entity);

            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<ClientCard> Delete(string id)
        {
            var res = int.TryParse(id, out var cardID);

            var card = context.ClientCard.Find(cardID);

            if (id == null || !res || card == null)
                throw new ArgumentNullException();

            context.ClientCard.Remove(card);

            await context.SaveChangesAsync();

            return card;
        }

        public async Task<IEnumerable<ClientCard>> GetAll()
        {
            return context.ClientCard.ToList();
        }

        public async Task<ClientCard> GetByID(string id)
        {
            var res = int.TryParse(id, out var cardID);
            if (id == null || !res)
                throw new ArgumentNullException();

            return context.ClientCard.Find(cardID);
        }

        public async Task<ClientCard> Update(ClientCard entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            context.ClientCard.Update(entity);

            await context.SaveChangesAsync();

            return entity;
        }
    }
}
