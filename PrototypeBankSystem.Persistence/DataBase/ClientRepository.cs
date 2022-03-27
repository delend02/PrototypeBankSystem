using Microsoft.EntityFrameworkCore;
using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;
using System.Collections.ObjectModel;

namespace PrototypeBankSystem.Persistence.DataBase
{
    public class ClientRepository
            : IRepository<Client>
    {
       

        #region Create
        public async Task CreateClient(Client entity)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Client.AddAsync(entity);
                db.SaveChanges();
            }
        }

       
        public async Task CreateCard(ClientCard entity)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.ClientCard.AddAsync(entity);
                db.SaveChanges();
            }
        }

        public async Task CreateCredit(Credit entity)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                await db.Credit.AddAsync(entity);
                db.SaveChanges();
            }
        }

        public async Task CreateDeposit(Deposit entity)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                await db.Deposit.AddAsync(entity);
                db.SaveChanges();
            }
        }

        #endregion

        #region GetData
        public async Task<IEnumerable<Client>> GetAllClient()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Client
                   .Include(cc => cc.ClientCard)
                       .ThenInclude(c => c.Deposits)
                           .ToList();
                return result;
            }
        }
        #endregion



    }
}
