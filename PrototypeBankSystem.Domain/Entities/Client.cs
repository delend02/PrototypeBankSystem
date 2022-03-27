using System.Collections.ObjectModel;

namespace PrototypeBankSystem.Domain.Entities
{
    public class Client
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public byte Age { get; set; }
        public string NumberPhone { get; set; }
        public string Privilege { get; set; }
        public IEnumerable<ClientCard> ClientCard { get; set; } = new ObservableCollection<ClientCard>();


        public Client()
        {
        }

        public Client(string firstName, string lastName, string surName, byte age, string numberPhone, string privilege)
        {
            ID = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            SurName = surName;
            Age = age;
            NumberPhone = numberPhone;
            Privilege = privilege;
        }

    }
}
