namespace PrototypeBankSystem.Domain.Entities
{
    public class CreditCard
    {
        public string Number { get; set; } 
        public string CarrierName { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Cash { get; set; }
        public IList<Credit> CreditHistory { get; set; } = new List<Credit>();
        public IList<Deposit> DepositHisory { get; set; } = new List<Deposit>();
        public bool Blocked { get; set; }

        public CreditCard(string number, string carrierName, DateTime dateCreate, DateTime expirationDate)
        {
            Number = number;
            CarrierName = carrierName;
            //DateCreate = DateTime.Now;
            //ExpirationDate = DateTime.Now.AddYears(4);
            DateCreate = dateCreate;
            ExpirationDate = expirationDate;
        }
    }
}
