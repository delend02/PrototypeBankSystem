using System.Collections.ObjectModel;
using System.Text.Json.Serialization;

namespace PrototypeBankSystem.BLL.Entities
{
    public class ClientCard
    {
        public string Number { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Cash { get; set; }
        public Guid ClientID { get; set; }
        public int ID { get; set; }
        public ObservableCollection<Credit> Credits { get; set; } = new ObservableCollection<Credit>();
        public ObservableCollection<Deposit> Deposits { get; set; } = new ObservableCollection<Deposit>();


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
