using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Persistence.DataBase.Repository
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
            return context.Credit.Where(c => c.ID == entity.ID).SingleOrDefault();
        }

        public async Task<Credit> Delete(string id)
        {
            //var res = int.TryParse(id, out var cardID);

            //var card = context.Credit.Where(c => c.ID == cardID).SingleOrDefault();

            //if (id == null || !res || card == null)
            //    throw new ArgumentNullException();

            //var param1 = new SqlParameter("@cardID", cardID);

            //await context.Database.ExecuteSqlRawAsync("DELETE FROM Credit WHERE ClientCardID = @cardID", param1);

            //return card;
        }

        public async Task<IEnumerable<Credit>> GetAll()
        {
            return context.Credit.ToList();
        }

        public async Task<Credit> GetByID(string id)
        {
            var res = int.TryParse(id, out var cardID);
            if (id == null || !res)
                throw new ArgumentNullException();

            return context.Credit.Where(c => c.ID == cardID).SingleOrDefault();
        }

        public async Task<Credit> Update(Credit entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            context.Credit.Update(entity);
            return entity;
        }
    }
}
