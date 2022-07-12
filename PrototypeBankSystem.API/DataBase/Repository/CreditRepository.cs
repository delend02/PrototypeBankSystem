namespace PrototypeBankSystem.API.DataBase.Repository
{
    public class CreditRepository : IRepository<Credit>
    {
        readonly ApplicationContext context;

        public CreditRepository(ApplicationContext db)
        {
            context = db;
        }

        public async Task<Credit> Create(Credit entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            await context.Credit.AddAsync(entity);

            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<Credit> Delete(string id)
        {
            var res = int.TryParse(id, out var creditID);

            var card = await context.Credit.FindAsync(creditID);

            if (id == null || !res || card == null)
                throw new ArgumentNullException();

            context.Credit.Remove(card);

            await context.SaveChangesAsync();

            return card;
        }

        public async Task<IEnumerable<Credit>> GetAll()
        {
            return context.Credit.ToList();
        }

        public async Task<Credit> GetByID(string id)
        {
            var res = int.TryParse(id, out var creditID);
            if (id == null || !res)
                throw new ArgumentNullException();

            return await context.Credit.FindAsync(creditID);
        }

        public async Task<Credit> Update(Credit entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            context.Credit.Update(entity);

            await context.SaveChangesAsync();

            return entity;
        }
    }
}
