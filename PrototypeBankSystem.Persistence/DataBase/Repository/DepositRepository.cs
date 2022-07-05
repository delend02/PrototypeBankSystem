namespace PrototypeBankSystem.Persistence.DataBase.Repository
{
    public class DepositRepository : IRepository<Deposit>
    {
        readonly ApplicationContext context;

        public DepositRepository(ApplicationContext db)
        {
            context = db;
        }

        public async Task<Deposit> Create(Deposit entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            var paramAmout = new SqlParameter("@AmountOfDeposit", entity.AmountOfDeposit);
            var paramRateType = new SqlParameter("@RateType", entity.RateType);
            var paramDepositStart = new SqlParameter("@DepositStart", entity.DepositStart);
            var paramDepositStop = new SqlParameter("@DepositStop", entity.DepositStop);
            var paramInterestRate = new SqlParameter("@InterestRate", entity.InterestRate);
            var paramNumberCardID = new SqlParameter("@ClientCardID", entity.ClientCardID);

            await context.Database.ExecuteSqlRawAsync(
                   @"INSERT INTO [dbo].[Deposit]
                                ([AmountOfDeposit]
                                ,[RateType]
                                ,[DepositStart]
                                ,[DepositStop]
                                ,[InterestRate]
                                ,[ClientCardID])
                            VALUES
                                (@AmountOfDeposit,
                                 @RateType,
                                 @DepositStart,
                                 @DepositStop,
                                 @InterestRate,
                                 @ClientCardID)",
                   paramAmout, paramRateType, paramDepositStart, paramDepositStop, paramInterestRate, paramNumberCardID);

            return entity;
        }

        public async Task<Deposit> Delete(string id)
        {
            var res = int.TryParse(id, out var depositID);

            var deposit = context.Deposit.Where(c => c.ID == depositID).SingleOrDefault();

            if (id == null || !res || deposit == null)
                throw new ArgumentNullException();

            var param1 = new SqlParameter("@depositID", depositID);

            await context.Database.ExecuteSqlRawAsync("DELETE FROM Deposit WHERE ID = @depositID", param1);

            return deposit;
        }

        public async Task<IEnumerable<Deposit>> GetAll()
        {
            return context.Deposit.ToList();
        }

        public async Task<Deposit> GetByID(string id)
        {
            var res = int.TryParse(id, out var cardID);
            if (id == null || !res)
                throw new ArgumentNullException();

            return context.Deposit.Where(c => c.ID == cardID).SingleOrDefault();
        }

        public async Task<Deposit> Update(Deposit entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            var paramID = new SqlParameter("@ID", entity.ID);

            var paramAmout = new SqlParameter("@AmountOfDeposit", entity.AmountOfDeposit);
            var paramRateType = new SqlParameter("@RateType", entity.RateType);
            var paramDepositStart = new SqlParameter("@DepositStart", entity.DepositStart);
            var paramDepositStop = new SqlParameter("@DepositStop", entity.DepositStop);
            var paramInterestRate = new SqlParameter("@InterestRate", entity.InterestRate);
            var paramNumberCardID = new SqlParameter("@ClientCardID", entity.ClientCardID);

            await context.Database.ExecuteSqlRawAsync(
                   @"UPDATE [dbo].[Deposit]
                        SET [AmountOfDeposit] = @AmountOfDeposit,
                            [RateType] = @RateType,
                            [DepositStart] = @DepositStart,
                            [DepositStop] = @DepositStop,
                            [InterestRate] = @InterestRate,
                            [ClientCardID] = @ClientCardID
                        WHERE ID = @ID",
                   paramAmout, paramRateType, paramDepositStart, paramDepositStop, paramInterestRate, paramNumberCardID, paramID);

            return entity;
        }
    }
}
