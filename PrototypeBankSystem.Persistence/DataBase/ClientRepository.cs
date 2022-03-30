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
            using ApplicationContext db = new();
            await db.Client.AddAsync(entity);
            db.SaveChanges();
        }

       
        public async Task CreateCard(ClientCard entity)
        {
            using ApplicationContext db = new();
            await db.ClientCard.AddAsync(entity);
            db.SaveChanges();
        }

        public async Task CreateCredit(Credit entity)
        {
            using ApplicationContext db = new();
            await db.Credit.AddAsync(entity);
            db.SaveChanges();
        }

        public async Task CreateDeposit(Deposit entity)
        {
            using ApplicationContext db = new();
            await db.Deposit.AddAsync(entity);
            db.SaveChanges();
        }

        #endregion

        #region GetData
        public async Task<IEnumerable<Client>> GetAllClient()
        {
            using ApplicationContext db = new();
            var result = db.Client
               .Include(cc => cc.ClientCard)
                   .ThenInclude(c => c.Deposits)
                       .ToList();
            return result;
        }
        #endregion

        #region Update
        public async Task UpdateClientCard(ClientCard entity)
        {
            using ApplicationContext db = new();
            db.ClientCard.Update(entity);
            db.SaveChanges();
        }

        public async Task UpdateClient(Client entity)
        {
            using ApplicationContext db = new();
            db.Client.Update(entity);
            db.SaveChanges();
        }

        public async Task UpdateDeposit(Deposit entity)
        {
            using ApplicationContext db = new();
            db.Deposit.Update(entity);
            db.SaveChanges();
        }

        public async Task UpdateCredit(Credit entity)
        {
            using ApplicationContext db = new();
            db.Credit.Update(entity);
            db.SaveChanges();
        }
        #endregion
    }
}
