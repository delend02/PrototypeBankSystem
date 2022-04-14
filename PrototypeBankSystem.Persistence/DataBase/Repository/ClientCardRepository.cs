using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;

namespace PrototypeBankSystem.Persistence.DataBase.Repository
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
            return context.ClientCard.Where(c => c.ID == entity.ID).SingleOrDefault();
        }

        public async Task<ClientCard> Delete(string id)
        {
            //var res = int.TryParse(id, out var cardID);

            //var card = context.ClientCard.Where(c => c.ID == cardID).SingleOrDefault();

            //if (id == null || !res || card == null)
            //    throw new ArgumentNullException();

            //var param1 = new SqlParameter("@cardID", cardID);

            //await context.Database.ExecuteSqlRawAsync("DELETE FROM Credit WHERE ClientCardID = @cardID", param1);

            //await context.Database.ExecuteSqlRawAsync("DELETE FROM Deposit WHERE ClientCardID = @cardID", param1);

            //await context.Database.ExecuteSqlRawAsync("DELETE FROM ClientCard WHERE ID = @cardID", param1);

            //return card;
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

            await context.Database.ExecuteSqlRawAsync($"");
            return context.ClientCard.Where(c => c.ID == cardID).SingleOrDefault();
        }

        public async Task<ClientCard> Update(ClientCard entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            context.ClientCard.Update(entity);
            return entity;
        }
    }
}
