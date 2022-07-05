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

            var paramAmout = new SqlParameter("@AmountOfCredit", entity.AmountOfCredit);
            var paramCreditStart = new SqlParameter("@CreditStart", entity.CreditStart);
            var paramCreditStop = new SqlParameter("@CreditStop", entity.CreditStop);
            var paramInterestRate = new SqlParameter("@InterestRate", entity.InterestRate);
            var paramReapidLoan = new SqlParameter("@RepaidLoan", entity.RepaidLoan);
            var paramNumberCardID = new SqlParameter("@ClientCardID", entity.ClientCardID);

            await context.Database.ExecuteSqlRawAsync(
                   @"INSERT INTO [dbo].[Credit]
                    ([AmountOfCredit]
                    ,[CreditStart]
                    ,[CreditStop]
                    ,[InterestRate]
                    ,[RepaidLoan]
                    ,[ClientCardID])
                VALUES
                    (@AmountOfCredit,
                     @CreditStart,
                     @CreditStop,
                     @InterestRate,
                     @RepaidLoan,
                     @ClientCardID)",
                   paramAmout, paramCreditStart, paramCreditStop, paramInterestRate, paramReapidLoan, paramNumberCardID);

            return entity;
        }

        public async Task<Credit> Delete(string id)
        {
            var res = int.TryParse(id, out var creditID);

            var card = context.Credit.Where(c => c.ID == creditID).SingleOrDefault();

            if (id == null || !res || card == null)
                throw new ArgumentNullException();

            var param1 = new SqlParameter("@creditID", creditID);

            await context.Database.ExecuteSqlRawAsync("DELETE FROM Credit WHERE ID = @creditID", param1);

            return card;
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

            var paramID = new SqlParameter("@ID", entity.ID);

            var paramAmout = new SqlParameter("@AmountOfCredit", entity.AmountOfCredit);
            var paramCreditStart = new SqlParameter("@CreditStart", entity.CreditStart);
            var paramCreditStop = new SqlParameter("@CreditStop", entity.CreditStop);
            var paramInterestRate = new SqlParameter("@InterestRate", entity.InterestRate);
            var paramReapidLoan = new SqlParameter("@RepaidLoan", entity.RepaidLoan);
            var paramNumberCardID = new SqlParameter("@ClientCardID", entity.ClientCardID);

            await context.Database.
                ExecuteSqlRawAsync(@"UPDATE [dbo].[Credit]
                                        SET [AmountOfCredit] = @AmountOfCredit,
                                            [CreditStart] = @CreditStart,
                                            [CreditStop] = @CreditStop,
                                            [InterestRate] = @InterestRate,
                                            [RepaidLoan] = @RepaidLoan,
                                            [ClientCardID] = @ClientCardID
                                        WHERE ID = @ID",
                                    paramAmout, paramCreditStart, paramCreditStop, paramInterestRate, 
                                    paramReapidLoan, paramNumberCardID, paramID);

            return entity;
        }
    }
}
