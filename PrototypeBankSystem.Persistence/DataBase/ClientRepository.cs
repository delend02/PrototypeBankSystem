using PrototypeBankSystem.Application.DateBase;
using PrototypeBankSystem.Domain.Entities;
using System.Collections.ObjectModel;

namespace PrototypeBankSystem.Persistence.DataBase
{
    public class ClientRepository 
            : IRepository<Client>
    {

        private ClientData _clientData = new();

        

        public async Task CreateClient(Client entity)
        {
            await _clientData.SaveData(@"INSERT INTO [dbo].[Client]
           ([ID]
           ,[FIRST_NAME]
           ,[LAST_NAME]
           ,[SUR_NAME]
           ,[AGE]
           ,[NUMBER_PHONE]
           ,[PRIVILAGE])
                VALUES
            (@ID,
            @FirstName, 
            @LastName, 
            @SurName, 
            @Age,
            @NumberPhone,
            @Privilege)",
            new {entity.ID, entity.FirstName, entity.LastName, entity.SurName, entity.Age,
                                entity.NumberPhone, entity.Privilege});
        }

        public async Task CreateCard(CreditCard entity)
        {
            await _clientData.SaveData(@"INSERT INTO [dbo].[ClientCard]
                                       ([NUMBER]
                                       ,[DATE_CREATE]
                                       ,[ExpirationDate]
                                       ,[Cash]
                                       ,[CLIENT_ID])
                                            VALUES(
                                        @Number,
                                        GETDATE(),
                                        DATEADD(year,4,GETDATE()),
                                        @Cash,
                                        @ClientID)",
                                       new { entity.Number, entity.Cash, entity.ClientID});
        }

        public async Task CreateCredit(Credit entity)
        {
            
        }

        public async Task CreateDeposit(Deposit entity)
        {
            
        }


        public async Task Delete(Client entity)
        {
            
        }
        
        public async Task<IEnumerable<Client>> GetAllClient()
        {
            var res = await _clientData.LoadData<Client>(
            @"SELECT [ID] as id
                ,[FIRST_NAME] as firstName
                ,[LAST_NAME] as lastName
                ,[SUR_NAME] as surName
                ,[AGE] as age
                ,[NUMBER_PHONE] as numberPhone
                ,[PRIVILAGE] as privilege
            FROM [dbo].[Client]", null);

            return res;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            await _clientData.LoadData<Client>(
                @"SELECT [ID] as id
                  ,[FIRST_NAME] as FirstName
                  ,[LAST_NAME]  as LastName
                  ,[SUR_NAME] as SurName
                  ,[AGE] as Age
                  ,[NUMBER_PHONE] as NumberPhone
                  ,[PRIVILAGE] as Privilege
                  ,[CLIENT_CARD_NUMBER] as Number
                FROM [dbo].[Client]", null);
            return null;
        }

        public async Task Save(IEnumerable<Client> ts)
        {
            
        }

        public async Task Update(Client entity, Client entityOld)
        {
            
        }

        
    }
}
