namespace PrototypeBankSystem.Domain.Entities
{
    public class CreditCardDTO
    {
        public string Number { get; set; } 
        public string CarrierName { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Cash { get; set; }
        public IList<CreditDTO> CreditHistory { get; set; } = new List<CreditDTO>();
        public IList<DepositDTO> DepositHisory { get; set; } = new List<DepositDTO>();
        public bool Blocked { get; set; }

        public CreditCardDTO(string number, string carrierName, DateTime dateCreate, DateTime expirationDate)
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
