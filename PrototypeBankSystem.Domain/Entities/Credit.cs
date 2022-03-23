namespace PrototypeBankSystem.Domain.Entities
{
    public class Credit
    {
        public string NumberCreditCard { get; set; }
        public double AmountOfCredit { get; set; }
        public DateTime CreditStart { get; set; }
        public DateTime CreditStop { get; set; }
        public float InterestRate { get; set; }
        public bool RepaidLoan { get; set; }

        public Credit()
        {
        }

        public Credit(double amountOfCredit, DateTime creditStart, DateTime creditStop, float interestRate, bool repaidLoan = false)
        {
            AmountOfCredit = amountOfCredit;
            CreditStart = creditStart;
            CreditStop = creditStop;
            InterestRate = interestRate;
            RepaidLoan = repaidLoan;
        }
    }
}
