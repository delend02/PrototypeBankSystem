namespace PrototypeBankSystem.Domain.Entities
{
    public class History
    {

        public int ID { get; set; }
        public string Event { get; set; }
        public Guid ClientID { get; set; }
        public int? ClientCArdID { get; set; }
        public int? CreditID { get; set; }
        public int? DepositID { get; set; }
        public DateTime CreateAt { get; set; }

        public History(int ID, string Event, Guid clientID, int? clientCArdID, int? creditID, int? depositID, DateTime createAt)
        {
            this.ID = ID;
            this.Event = Event;
            ClientID = clientID;
            ClientCArdID = clientCArdID;
            CreditID = creditID;
            DepositID = depositID;
            CreateAt = createAt;
        }
        
    }
}
