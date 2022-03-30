using System.Collections.ObjectModel;

namespace PrototypeBankSystem.Domain.Entities
{
    public class ClientCard
    {
        public int ID { get; set; }
        public string Number { get; private set; }
        public Guid ClientID { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Cash { get; set; }
        public ObservableCollection<Credit> Credits { get; set; } = new ObservableCollection<Credit>();
        public ObservableCollection<Deposit> Deposits { get; set; } = new ObservableCollection<Deposit>();
        public Client Client { get; set; }


        public ClientCard()
        {

        }

        public ClientCard(Guid clientID, string number,  int cash)
        {
            ClientID = clientID;
            DateCreate = DateTime.Now;
            ExpirationDate = DateTime.Now.AddYears(5);
            Number = number;
            Cash = cash;
        }
    }
}
