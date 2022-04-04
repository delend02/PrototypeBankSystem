namespace PrototypeBankSystem.Domain.Entities
{
    public class Credit
    {
        public int ID { get; set; }
        public double AmountOfCredit { get; set; }
        public DateTime CreditStart { get; set; }
        public DateTime CreditStop { get; set; }
        public double InterestRate { get; set; }
        public bool RepaidLoan { get; set; }
        public int ClientCardID { get; set; }
        public ClientCard ClientCard { get; set; }

        public Credit()
        {
        }

        public Credit(int clCardID, double  amountOfCredit, DateTime creditStart, DateTime creditStop, double interestRate, bool repaidLoan = false)
        {
            ClientCardID = clCardID;
            AmountOfCredit = amountOfCredit;
            CreditStart = creditStart;
            CreditStop = creditStop;
            InterestRate = interestRate;
            RepaidLoan = repaidLoan;
        }
    }
}
