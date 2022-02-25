namespace PrototypeBankSystem.Domain.Entities
{
    public class Client
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public string NumberPhone { get; set; }
        public string Privilege { get; set; }
        public CreditCard ClientCard { get; set; }
        public bool DoEvent { get; set; }

        public Client(string firstName, string lastName, string surName, int age, string numberPhone, string privilege, CreditCard creditCard, bool doEvent)
        {
            ID = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            SurName = surName;
            Age = age;
            NumberPhone = numberPhone;
            Privilege = privilege;
            ClientCard = creditCard;
            DoEvent = doEvent;
        }

    }
}
