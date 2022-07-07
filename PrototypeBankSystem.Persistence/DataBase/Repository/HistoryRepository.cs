namespace PrototypeBankSystem.Persistence.DataBase.Repository
{
    public class HistoryRepository : IRepository<History>
    {
        readonly ApplicationContext context;

        public HistoryRepository(ApplicationContext db)
        {
            context = db;
        }

        public Task<History> Create(History entity)
        {
            throw new NotImplementedException();
        }

        public Task<History> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<History>> GetAll()
        {
            var his = context.History.OrderByDescending(x => x.ID);
            var a = his.Take(15);
            return a;
        }

        public Task<History> GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public Task<History> Update(History entity)
        {
            throw new NotImplementedException();
        }
    }
}
