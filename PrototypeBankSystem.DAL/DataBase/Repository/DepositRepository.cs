using PrototypeBankSystem.BLL.Entities;

namespace PrototypeBankSystem.DAL.DataBase.Repository
{
    public class DepositRepository : IRepository<Deposit>
    {
        readonly ApplicationContext context;

        public DepositRepository(ApplicationContext db)
        {
            context = db;
        }

        public async Task<Deposit> Create(Deposit entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            await context.Deposit.AddAsync(entity);

            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<Deposit> Delete(string id)
        {
            var res = int.TryParse(id, out var depositID);

            var deposit = await context.Deposit.FindAsync(depositID);

            if (id == null || !res || deposit == null)
                throw new ArgumentNullException();

            context.Deposit.Remove(deposit);

            await context.SaveChangesAsync();

            return deposit;
        }

        public async Task<IEnumerable<Deposit>> GetAll()
        {
            return context.Deposit.ToList();
        }

        public async Task<Deposit> GetByID(string id)
        {
            var res = int.TryParse(id, out var depositID);
            if (id == null || !res)
                throw new ArgumentNullException();

            return await context.Deposit.FindAsync(depositID);
        }

        public async Task<Deposit> Update(Deposit entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            context.Deposit.Update(entity);

            await context.SaveChangesAsync();

            return entity;
        }
    }
}
