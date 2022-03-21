using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;
using System.Collections.ObjectModel;

namespace PrototypeBankSystem.Persistence.DataBase
{
    public class ClientRepository : IRepository<Client>
    {
        private static ObservableCollection<Client> _client = new();

        private ClientData _clientData = new();

        public async Task Create(Client entity)
        {
            await _clientData.SaveData(@"INSERT INTO[dbo].[ClientCard]
           ([NUMBER]
           ,[DATE_CREATE]
           ,[ExpirationDate]
           ,[Cash])
     VALUES (
           @Number,
           GETDATE(),
           GETDATE(),
           @Cash)", new { entity.ClientCard.Number, entity.ClientCard.ExpirationDate, entity.ClientCard.Cash});

            await _clientData.SaveData(@"INSERT INTO [dbo].[Client]
           ([ID]
           ,[FIRST_NAME]
           ,[LAST_NAME]
           ,[SUR_NAME]
           ,[AGE]
           ,[NUMBER_PHONE]
           ,[PRIVILAGE]
           ,[CLIENT_CARD_NUMBER])
     VALUES
           (NEWID(),
           @FirstName, 
           @LastName, 
           @SurName, 
           @Age,
           @NumberPhone,
           @Privilege,
           @Number)", new {entity.FirstName, entity.LastName, entity.SurName, entity.Age,
                                entity.NumberPhone, entity.Privilege, entity.ClientCard.Number});
        }

        public async Task Delete(Client entity)
        {
            _client.Remove(entity);
        }

        public  IEnumerable<Client> GetAll()
        {
            return _client;
        }

        public async Task Save(IEnumerable<Client> ts)
        {
            _client = (ObservableCollection<Client>)ts;
        }

        public async Task Update(Client entity, Client entityOld)
        {
            
        }
    }
}
