using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;

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


            var paramID = new SqlParameter("@ID", entity.ID);
            var paramFirstName = new SqlParameter("@FirstName", entity.FirstName);
            var paramLastName = new SqlParameter("@LastName", entity.LastName);
            var paramSurName = new SqlParameter("@SurName", entity.SurName);
            var paramAge = new SqlParameter("@Age", entity.Age);
            var paramNumberPhone = new SqlParameter("@NumberPhone", entity.NumberPhone);
            var paramPrivilage = new SqlParameter("@Privilege", entity.Privilege);

            await context.Database.ExecuteSqlRawAsync(
                   @"INSERT INTO [dbo].[Client]
                                ([ID]
                                ,[FirstName]
                                ,[LastName]
                                ,[SurName]
                                ,[Age]
                                ,[NumberPhone]
                                ,[Privilege])
                            VALUES
                                (@ID,
                                 @FirstName,
                                 @LastName,
                                 @SurName,
                                 @Age,
                                 @NumberPhone,
                                 @Privilege)",
                   paramID, paramFirstName, paramLastName, paramSurName, paramAge, paramNumberPhone, paramPrivilage);

            return context.Client.Where(c => c.ID == entity.ID).SingleOrDefault();
        }

        public async Task<Client> Delete(string id)
        {
            var res = Guid.TryParse(id, out var clientID);

            var client = context.Client.Where(c => c.ID == clientID).SingleOrDefault();

            if (id == null || !res || client == null)
                throw new ArgumentNullException();

            var paramClient = new SqlParameter("@clientID", clientID);

            await context.Database.ExecuteSqlRawAsync("DELETE FROM Client WHERE ID = @clientID", paramClient);

            return client;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {

            return context.Client.ToList();
        }

        public async Task<Client> GetByID(string id)
        {
            var res = Guid.TryParse(id, out var cardID);
            if (id == null || !res)
                throw new ArgumentNullException();

            return context.Client.Where(c => c.ID == cardID).SingleOrDefault();
        }

        public async Task<Client> Update(Client entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            var paramID = new SqlParameter("@ID", entity.ID);

            var paramFirstName = new SqlParameter("@FirstName", entity.FirstName);
            var paramLastName = new SqlParameter("@LastName", entity.LastName);
            var paramSurName = new SqlParameter("@SurName", entity.SurName);
            var paramAge = new SqlParameter("@Age", entity.Age);
            var paramNumberPhone = new SqlParameter("@NumberPhone", entity.NumberPhone);
            var paramPrivilage = new SqlParameter("@Privilege", entity.Privilege);

            await context.Database.
                ExecuteSqlRawAsync(@"UPDATE [dbo].[Client]
                                       SET [FirstName] = @FirstName,
                                           [LastName] = @LastName,
                                           [SurName] = @SurName,
                                           [Age] = @Age,
                                           [NumberPhone] = @NumberPhone,
                                           [Privilege] = @Privilege
                                     WHERE ID = @ID",
                                    paramFirstName, paramLastName, paramSurName, paramAge, 
                                    paramNumberPhone, paramPrivilage, paramID);

            return entity;
        }
    }
}
