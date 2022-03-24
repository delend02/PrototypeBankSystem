namespace PrototypeBankSystem.Domain.Entities
{
    public class CreditCard
    {
        public string Number { get; set; }
        public Guid ClientID { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Cash { get; set; }
        public bool Blocked { get; set; }

        public CreditCard()
        {

        }

        public CreditCard(Guid clientID, string number,  double cash)
        {
            ClientID = clientID;
            Number = number;
            Cash = cash;
        }
    }
}
