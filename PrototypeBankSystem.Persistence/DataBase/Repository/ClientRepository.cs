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

            entity.ID = Guid.NewGuid();
            context.Client.Add(entity);
            return context.Client.Where(c => c.ID == entity.ID).SingleOrDefault();
        }

        public async Task<Client> Delete(string id)
        {
            //var res = Guid.TryParse(id, out var clientID);

            //var client = context.Client.Where(c => c.ID == clientID).SingleOrDefault();

            //if (id == null || !res || client == null)
            //    throw new ArgumentNullException();


            //var paramClient = new SqlParameter("@clientID", clientID);
            ////var paramCard = new SqlParameter("@cardID", )

            ////await context.Database.ExecuteSqlRawAsync("DELETE FROM Credit WHERE ClientCardID = @cardID", );

            ////await context.Database.ExecuteSqlRawAsync("DELETE FROM Deposit WHERE ClientCardID = @cardID", );

            ////await context.Database.ExecuteSqlRawAsync("DELETE FROM ClientCard WHERE ID = @cardID", );

            //await context.Database.ExecuteSqlRawAsync("DELETE FROM Client WHERE ID = @clientID", paramClient);

            //return client;
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

            context.Client.Update(entity);
            return entity;
        }
    }
}
