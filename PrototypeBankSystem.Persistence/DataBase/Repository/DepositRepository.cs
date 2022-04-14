using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Persistence.DataBase.Repository
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
            return context.Deposit.Where(c => c.ID == entity.ID).SingleOrDefault();
        }

        public async Task<Deposit> Delete(string id)
        {
            //var res = int.TryParse(id, out var cardID);

            //var card = context.Deposit.Where(c => c.ID == cardID).SingleOrDefault();

            //if (id == null || !res || card == null)
            //    throw new ArgumentNullException();

            //var param1 = new SqlParameter("@cardID", cardID);

            //await context.Database.ExecuteSqlRawAsync("DELETE FROM Credit WHERE ClientCardID = @cardID", param1);

            //await context.Database.ExecuteSqlRawAsync("DELETE FROM Deposit WHERE ClientCardID = @cardID", param1);

            //await context.Database.ExecuteSqlRawAsync("DELETE FROM ClientCard WHERE ID = @cardID", param1);

            //return card;
        }

        public async Task<IEnumerable<Deposit>> GetAll()
        {
            return context.Deposit.ToList();
        }

        public async Task<Deposit> GetByID(string id)
        {
            var res = int.TryParse(id, out var cardID);
            if (id == null || !res)
                throw new ArgumentNullException();

            return context.Deposit.Where(c => c.ID == cardID).SingleOrDefault();
        }

        public async Task<Deposit> Update(Deposit entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            context.Deposit.Update(entity);
            return entity;
        }
    }
}
