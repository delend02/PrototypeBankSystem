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

            var paramNumber = new SqlParameter("@Number", entity.Number);
            var paramDateCreate = new SqlParameter("@DateCreate", entity.DateCreate);
            var paramDateExperation = new SqlParameter("@ExpirationDate", entity.ExpirationDate);
            var paramCash = new SqlParameter("@Cash", entity.Cash);
            var paramClientID = new SqlParameter("@ClientID", entity.ClientID);

            await context.Database.ExecuteSqlRawAsync(
                   @"INSERT INTO [dbo].[ClientCard]
                                ([Number]
                                ,[DateCreate]
                                ,[ExpirationDate]
                                ,[Cash]
                                ,[ClientID])
                            VALUES
                                (@Number,
                                @DateCreate,
                                @ExpirationDate,
                                @Cash,
                                @ClientID)",
                   paramNumber, paramDateCreate, paramDateExperation, paramCash, paramClientID);

            return context.ClientCard.Where(c => c.ID == entity.ID).SingleOrDefault();
        }

        public async Task<ClientCard> Delete(string id)
        {
            var res = int.TryParse(id, out var cardID);

            var card = context.ClientCard.Where(c => c.ID == cardID).SingleOrDefault();

            if (id == null || !res || card == null)
                throw new ArgumentNullException();

            var param1 = new SqlParameter("@cardID", cardID);

            await context.Database.ExecuteSqlRawAsync("DELETE FROM ClientCard WHERE ID = @cardID", param1);

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

            return context.ClientCard.Where(c => c.ID == cardID).SingleOrDefault();
        }

        public async Task<ClientCard> Update(ClientCard entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            var paramID = new SqlParameter("@ID", entity.ID);

            var paramNumber = new SqlParameter("@Number", entity.Number);
            var paramDateCreate = new SqlParameter("@DateCreate", entity.DateCreate);
            var paramExpDate = new SqlParameter("@ExpirationDate", entity.ExpirationDate);
            var paramCash = new SqlParameter("@Cash", entity.Cash);
            var paramClientID = new SqlParameter("@ClientID", entity.ClientID);

            await context.Database.
                ExecuteSqlRawAsync(@"UPDATE [dbo].[ClientCard]
                                    SET  [Number] = @Number,
                                         [DateCreate] = @DateCreate,
                                         [ExpirationDate] = @ExpirationDate,
                                         [Cash] = @Cash,
                                         [ClientID] = @ClientID
                                    WHERE ID = @ID",
                                    paramNumber, paramDateCreate, paramExpDate, 
                                    paramCash, paramClientID, paramID);
            


            return entity;
        }
    }
}
